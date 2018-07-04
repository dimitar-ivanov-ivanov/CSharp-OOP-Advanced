namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private Dummy dummy;

        [SetUp]
        public void Initialize()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            this.dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            this.dummy.TakeAttack(11);

            var ex = Assert.Throws<InvalidOperationException>
                  (() => dummy.TakeAttack(10));

            Assert.AreEqual(ex.Message, "Dummy is dead.",
                "Dead dummy can be attacked.");
        }

        [Test]
        public void DeadDummyGivesXp()
        {
            this.dummy.TakeAttack(11);

            var exp = dummy.GiveExperience();

            Assert.AreEqual(exp, 10, "Dead dummy doesn't give corrent experience");
        }

        [Test]
        public void AliveDummyCantGiveXp()
        {
            this.dummy.TakeAttack(6);

            var ex = Assert.Throws<InvalidOperationException>
                (() => dummy.GiveExperience());

            Assert.AreEqual(ex.Message, "Target is not dead.",
                "Alive dummy can give experience");
        }
    }
}