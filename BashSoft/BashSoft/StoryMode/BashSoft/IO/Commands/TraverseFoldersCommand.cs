namespace BashSoft.IO.Commands
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;
    using BashSoft.Static_data;

    [Alias("ls")]
    public class TraverseFoldersCommand : Command
    {
        [Inject]
        private IDirectoryManager InputOutputManager;

        public TraverseFoldersCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 1)
            {
                this.InputOutputManager.TraverseDirectory(0);
            }
            else if (this.Data.Length == 2)
            {
                int depth;
                bool hasParsed = int.TryParse(this.Data[1], out depth);
                if (hasParsed)
                {
                    this.InputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
                }
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
