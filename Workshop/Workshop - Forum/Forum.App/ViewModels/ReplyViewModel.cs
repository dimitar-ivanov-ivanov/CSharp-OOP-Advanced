namespace Forum.App.ViewModels
{
    using Forum.App.Contracts;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string text,string author) 
            : base(text)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}
