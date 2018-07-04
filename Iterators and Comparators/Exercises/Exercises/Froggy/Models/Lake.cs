namespace Froggy.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using Froggy.Contracts;

    public class Lake<T> : ILake<T>
    {
        private IList<int> data;

        public Lake(IList<int> data)
        {
            this.data = data;
        }

        public IList<int> Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Data.Count; i += 2)
            {
                yield return this.Data[i];
            }

            var start = this.Data.Count % 2 == 0 ?
                this.Data.Count - 1 :
                this.Data.Count - 2;

            for (int i = start; i >= 0; i -= 2)
            {
                yield return this.Data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
