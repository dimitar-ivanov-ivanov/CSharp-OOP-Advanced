namespace Create_Logger.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string layoutName);
    }
}
