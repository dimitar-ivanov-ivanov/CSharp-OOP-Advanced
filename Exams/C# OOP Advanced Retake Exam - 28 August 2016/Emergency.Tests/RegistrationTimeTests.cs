namespace Emergency.Tests
{
    using Emergency_Skeleton.Utils;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class RegistrationTimeTests
    {
        private Dictionary<string, FieldInfo> fields;

        [SetUp]
        public void TestInit()
        {
            this.fields = typeof(RegistrationTime)
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .ToDictionary(x => x.Name, y => y);
        }

        [TestCase("12:24 25/02/2016", 12, "hour")]
        [TestCase("12:24 25/02/2016", 24, "minutes")]
        [TestCase("12:24 25/02/2016", 25, "day")]
        [TestCase("12:24 25/02/2016", 02, "month")]
        [TestCase("12:24 25/02/2016", 2016, "year")]
        public void RegistersCorrectHour(string time, int amountToCheck, string fieldName)
        {
            var fieldToCheck = this.fields[fieldName];

            var registartionTime = new RegistrationTime(time);
            var fieldValue = (int)fieldToCheck.GetValue(registartionTime);

            Assert.AreEqual(fieldValue, amountToCheck,
               $"Value of given {fieldName} field is not correct.");
        }

        [Test]
        public void RegisterNullTime()
        {
            Assert.Throws<NullReferenceException>(() => new RegistrationTime(null));
        }
    }
}
