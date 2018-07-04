namespace LambdaCore.Tests
{
    using LambdaCore_Skeleton.Collection;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class LStackTests
    {
        private LStack<string> sut;

        [SetUp]
        public void TestInit()
        {
            this.sut = new LStack<string>();
        }

        [Test]
        public void StackPushItem()
        {
            var item = "a";
            sut.Push(item);

            Assert.AreEqual(sut.Count(), 1);
        }

        [Test]
        public void StackPushNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => sut.Push(null));
        }

        [Test]
        public void StackPopItem()
        {
            var item = "a";
            sut.Push(item);

            var popedItem = sut.Pop();

            Assert.AreEqual(sut.Count(), 0);
            Assert.AreEqual(item, popedItem);
        }

        [Test]
        public void StackPopItemThrowsExceptionWhenIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => sut.Pop());
        }
        
        [Test]
        public void StackPeekItem()
        {
            var item = "a";
            sut.Push(item);

            var peekedItem = sut.Peek();

            Assert.AreEqual(sut.Count(), 1);
            Assert.AreEqual(item, peekedItem);
        }

        [Test]
        public void StackPeekItemThrowsExceptionWhenIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => sut.Peek());
        }
    }
}
