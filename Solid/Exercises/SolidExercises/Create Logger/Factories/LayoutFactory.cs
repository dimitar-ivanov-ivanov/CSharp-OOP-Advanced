namespace Create_Logger.Factories
{
    using Create_Logger.Contracts;
    using Create_Logger.Models.Layouts;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string layoutName)
        {
            switch (layoutName)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
            }

            return null;
        }
    }
}
