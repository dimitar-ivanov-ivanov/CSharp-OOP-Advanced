namespace BashSoft.Repository
{
    using BashSoft.Contracts;
    using BashSoft.IO;
    using BashSoft.Models;
    using BashSoft.Static_data;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StudentsRepository : IDatabase
    {
        public bool isDataInitialized = false;
        private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        private IDataFilter filter;
        private IDataSorter sorter;
        private Dictionary<string, ICourse> courses;
        private Dictionary<string, IStudent> students;

        public StudentsRepository(IDataFilter filter, IDataSorter sorter)
        {
            this.sorter = sorter;
            this.filter = filter;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
                return;
            }

            this.students = new Dictionary<string, IStudent>();
            this.courses = new Dictionary<string, ICourse>();
            ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.students = null;
            this.courses = null;
            this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            this.isDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            var path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                var pattern = @"^([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)$";
                var rgx = new Regex(pattern);

                var allInputLines = File.ReadAllLines(path);
                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line])
                        && rgx.IsMatch(allInputLines[line]))
                    {
                        var currentMatch = rgx.Match(allInputLines[line]);
                        var courseName = currentMatch.Groups[1].Value;
                        var username = currentMatch.Groups[2].Value;
                        var scoresStr = currentMatch.Groups[3].Value;

                        try
                        {
                            int[] scores = scoresStr
                                           .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();
                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                            }
                            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }
                            if (!this.students.ContainsKey(username))
                            {
                                this.students.Add(username, new SoftUniStudent(username));
                            }
                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new SoftUniCourse(courseName));
                            }

                            ICourse course = this.courses[courseName];
                            IStudent student = this.students[username];

                            student.EnrollInCourse(course);
                            student.SetMarkOnCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                        catch (FormatException fex)
                        {
                            OutputWriter.DisplayException(fex.Message + $"at line {line}");
                        }
                    }

                }

                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) &&
               this.courses[courseName].StudentsByName
               .ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossible(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>
                    (username, this.courses[courseName]
                    .StudentsByName[username]
                    .MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");
                foreach (var studentMarkEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studentMarkEntry.Key);
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                var marks = this.courses[courseName]
                                    .StudentsByName
                                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                var marks = courses[courseName]
                                    .StudentsByName
                                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        public ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp)
        {
            var sortedCourses = new SimpleSortedList<ICourse>();
            sortedCourses.AddAll(this.courses.Values);

            return sortedCourses;
        }

        public ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp)
        {
            var sortedStudents = new SimpleSortedList<IStudent>(cmp);
            sortedStudents.AddAll(this.students.Values);

            return sortedStudents;
        }
    }
}
