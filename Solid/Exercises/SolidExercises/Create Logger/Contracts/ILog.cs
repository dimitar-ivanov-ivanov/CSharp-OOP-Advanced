namespace Create_Logger.Contracts
{
    public interface ILog
    {
        int Size { get; }

        void Write(string message);
    }
}
