namespace Custom_List_Iterator.Models
{
    using Custom_List_Iterator.Contracts;
    using System;
    using System.Text;

    public class CommandInterpreter<T>
        : ICommandInterpreter<T>
        where T : IComparable<T>
    {
        private ICustomList<T> customList;

        public CommandInterpreter()
        {
            this.customList = new CustomList<T>();
        }

        public ICustomList<T> CustomList
        {
            get { return this.customList; }
            set { this.customList = value; }
        }

        public void Add(T element)
        {
            this.CustomList.Add(element);
        }

        public bool Contains(T element)
        {
            return this.CustomList.Contains(element);
        }

        public int Greater(T element)
        {
            return this.CustomList.CountGreaterThan(element); 
        }

        public T Max()
        {
            return this.CustomList.Max();
        }

        public T Min()
        {
            return this.CustomList.Min();
        }

        public string Print()
        {
            var output = new StringBuilder();

            foreach (var item in this.CustomList)
            {
                output.AppendLine(item.ToString());
            }

            if(output.Length != 0)
            {
                output = output.Remove(output.Length - 2, 2);
            }

            return output.ToString();
        }

        public T Remove(int index)
        {
            return this.CustomList.Remove(index);
        }

        public void Sort()
        {
            this.CustomList = Sorter.Sort<T>(this.CustomList);
        }

        public void Swap(int index1, int index2)
        {
            this.CustomList.Swap(index1, index2);
        }
    }
}
