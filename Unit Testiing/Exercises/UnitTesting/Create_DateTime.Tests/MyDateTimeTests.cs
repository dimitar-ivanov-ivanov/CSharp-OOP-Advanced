namespace Create_DateTime.Tests
{
    using Create_DateTime.Models;
    using NUnit.Framework;
    using System;

    public class MyDateTimeTests
    {
        private MyDatetime myDatetime;

        [SetUp]
        public void InitializeMyDateTime()
        {
            this.myDatetime = new MyDatetime();
        }

        [Test]
        public void MyDateTimeGivesTheCurentTime()
        {
            Assert.AreEqual(myDatetime.Now(), DateTime.Now,
                "My date time doesnt give current date.");
        }

        [TestCase(10)]
        public void MyDateTimeSubstractDaysCorrectly(int daysToRemove)
        {
            var date = new DateTime(2012, 12, 15);

            var date1 = this.myDatetime.SubstractDays(date, daysToRemove);

            Assert.AreEqual(date1.TotalDays,daysToRemove,
                "");
        }
    }
}
