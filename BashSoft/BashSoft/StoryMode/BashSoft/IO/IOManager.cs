namespace BashSoft.IO
{
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using BashSoft.Static_data;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class IOManager : IDirectoryManager
    {
        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();

            var initialIndentation = SessionData.currentPath.Split('\\').Length;
            var subFolders = new Queue<string>();

            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count != 0)
            {
                var currentPath = subFolders.Dequeue();
                var indentation = currentPath.Split('\\').Length - initialIndentation;

                if (depth - indentation < 0)
                {
                    break;
                }

                OutputWriter.WriteMessageOnNewLine($"{new string('-', indentation)}{currentPath}");

                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        var indexOfLastSlash = file.LastIndexOf('\\');
                        var fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }

                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            var path = Directory.GetCurrentDirectory() + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            } 
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    var currentPath = SessionData.currentPath;
                    var indexOfLastSlash = currentPath.LastIndexOf('\\');
                    var newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new InvalidPathException();
                }
            }
            else
            {
                var currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
            }
            SessionData.currentPath = absolutePath;
        }
    }
}
