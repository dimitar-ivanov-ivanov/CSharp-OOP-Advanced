namespace Forum.App.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class ContentViewModel
    {
        private const int lineLength = 37;

        protected ContentViewModel(string text)
        {
            this.Content = GetLines(text);
        }

        public string[] Content { get; }

        private string[] GetLines(string content)
        {
            var contentChars = content.ToCharArray();

            var lines = new List<string>();

            for (int i = 0; i < content.Length; i+= lineLength)
            {
                var row = content.Skip(i).Take(lineLength).ToArray();
                var rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines.ToArray();
        }
    }
}
