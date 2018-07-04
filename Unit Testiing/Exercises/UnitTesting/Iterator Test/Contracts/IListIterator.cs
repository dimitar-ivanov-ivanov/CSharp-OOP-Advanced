namespace Iterator_Test.Contracts
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IListIterator : IEnumerator, IEnumerable<string>
    {
        string Print();

        bool HasNext();
    }
}