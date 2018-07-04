namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 1;
        private const int AxeDurability = 1;

        private const int DummyHealth = 20;
        private const int DummyExperience = 20;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            this.axe.Attack(this.dummy);

            Assert.AreEqual(0, axe.DurabilityPoints,
                "Axe durability doesn't change after attacks");
        }

        [Test]
        public void AttackingWithBrokenWeaponIsInvalid()
        {
            axe.Attack(dummy);

            var ex = Assert.Throws<InvalidOperationException>
                 (() => this.axe.Attack(this.dummy));

            Assert.AreEqual(ex.Message, "Axe is broken.", "Axe can attack even while broken");
        }
    }
}
