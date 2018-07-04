namespace LambdaCore.Tests
{
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Core;
    using LambdaCore_Skeleton.Factories;
    using NUnit.Framework;

    [TestFixture]
    public class PowerPlantTests
    {
        private IPowerPlant sut;

        [SetUp]
        public void TestInit()
        {
            this.sut = new PowerPlant(new FragmentFactory(), new CoreFactory());
            this.sut.CreateCore("System", 1000);
            this.sut.CreateCore("System", 2000);
            this.sut.CreateCore("Para", 3000);
            this.sut.CreateCore("Para", 4000);
        }

        [Test]
        public void SelectCoreSuccessfully()
        {
           var output = this.sut.SelectCore("A");

            Assert.AreEqual("Currently selected Core A!", output);
        }

        [Test]
        public void SelectCoreUnsuccessfully()
        {
            var output = this.sut.SelectCore("Z");

            Assert.AreEqual("Failed to select Core Z!", output);
        }

        [Test]
        public void AttachFragmentSuccsefully()
        {
            this.sut.SelectCore("A");

            var attached = this.sut.AttachFragment("A32", "Cooling", 500);

            Assert.AreEqual("Successfully attached Fragment A32 to Core A!", attached);
        }

        [Test]
        public void AttachingFragmentPressureIsNegative()
        {
            this.sut.SelectCore("A");

            var attached = this.sut.AttachFragment("A32", "Cooling", -500);

            Assert.AreEqual("Failed to attach Fragment A32!", attached);
        }

        [Test]
        public void AttachingFragmentNoSelectedCore()
        {
            var attached = this.sut.AttachFragment("A32", "Cooling", 500);

            Assert.AreEqual("Failed to attach Fragment A32!", attached);
        }

        [Test]
        public void DetachingFragmentIsSuccsessfull()
        {
            this.sut.SelectCore("A");

            var attached = this.sut.AttachFragment("A32", "Cooling", 500);

            var detached = this.sut.DetachFragment();

            Assert.AreEqual("Successfully detached Fragment A32 from Core A!", detached);
        }

        [Test]
        public void DetachingFragmentNoSelectedCore()
        {
            var attached = this.sut.AttachFragment("A32", "Cooling", 500);

            var detached = this.sut.DetachFragment();

            Assert.AreEqual("Failed to detach Fragment!", detached);
        }

        [Test]
        public void DetachingFragmentNoFragmentsInCore()
        {
            this.sut.SelectCore("A");

            var detached = this.sut.DetachFragment();

            Assert.AreEqual("Failed to detach Fragment!", detached);
        }
    }
}
