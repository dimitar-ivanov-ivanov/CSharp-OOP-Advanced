namespace Event_Implementation.Models
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs e);

    public class Dispatcher
    {
        private string name;

        private Handler handler;

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnNameChange(new NameChangeEventArgs(name));
            }
        }

        public event NameChangeEventHandler NameChange;

        public void OnNameChange(NameChangeEventArgs args)
        {
            if (NameChange != null)
            {
                this.NameChange.Invoke(this, args);
            }
        }
    }
}