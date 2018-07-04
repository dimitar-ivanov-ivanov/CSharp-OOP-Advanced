namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using System;
    using System.Collections.Generic;

    [Alias("display")]
    public class DisplayCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public DisplayCommand(string input, string[] data) 
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            var entityToDisplay = this.Data[1];
            var sortType = this.Data[2];

            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                var studentComparator = this.CreateStudentComparator(sortType);
                var list = this.repository.GetAllStudentsSorted(studentComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else
            {
                var courseComparator = this.CreateCourseComparator(sortType);
                var list = this.repository.GetAllCoursesSorted(courseComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
        }

        private IComparer<IStudent> CreateStudentComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((studentOne, studentTwo) => studentOne.CompareTo(studentTwo));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((studentOne, studentTwo) => studentTwo.CompareTo(studentOne));
            }

            throw new InvalidCommandException(this.Input);
        }

        private IComparer<ICourse> CreateCourseComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((courseOne, courseTwo) => courseOne.CompareTo(courseTwo));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((courseOne, courseTwo) => courseTwo.CompareTo(courseOne));
            }

            throw new InvalidCommandException(this.Input);
        }
    }
}
