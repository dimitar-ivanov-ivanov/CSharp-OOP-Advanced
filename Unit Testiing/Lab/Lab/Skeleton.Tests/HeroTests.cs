namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        private const string HeroName = "Pesho";

        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetIsDead()
        {
            var fakeTarget = new Mock<ITarget>();
            var fakeWeapon = new Mock<IWeapon>();

            fakeTarget.Setup(x => x.IsDead()).Returns(true);
            fakeTarget.Setup(x => x.Health).Returns(20);
            fakeTarget.Setup(x => x.GiveExperience()).Returns(20);

            fakeWeapon.Setup(x => x.AttackPoints).Returns(20);
            fakeWeapon.Setup(x => x.DurabilityPoints).Returns(20);

            var hero = new Hero(HeroName, fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(hero.Experience, 20,
                "Hero didn't gain experience even though target was dead.");
        }
    }
}
