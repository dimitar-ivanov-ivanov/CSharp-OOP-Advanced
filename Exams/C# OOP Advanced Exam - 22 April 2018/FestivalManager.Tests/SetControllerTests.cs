namespace FestivalManager.Tests
{
    //uncommented so that they the file  is accepted by judge
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System; 

    [TestFixture]
    public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;

        [SetUp]
        public void TestInit()
        {
           this.stage = new Stage();
           this.setController = new SetController(this.stage);
        }

        [Test]
        public void CanNotPerform()
        {
            this.stage.AddSet(new Short($"Set1"));

            var result = this.setController.PerformSets();

            Assert.AreEqual(result, "1. Set1:\r\n-- Did not perform");
        }

        [Test]
        public void PerformNoSets()
        {
            var result = this.setController.PerformSets();

            Assert.AreEqual(result, "");
        }

        [Test]
        public void CanPerform()
        {
            var set = new Short($"Set1");
            var performer = new Performer("Pesho", 15);
            var mic = new Microphone();
            var song = new Song("Time to rock", new TimeSpan(0, 1, 11));

            performer.AddInstrument(mic);
            set.AddPerformer(performer);
            set.AddSong(song);

            this.stage.AddPerformer(performer);
            this.stage.AddSong(song);
            this.stage.AddSet(set);

            var result = this.setController.PerformSets();

            Assert.AreEqual(result, "1. Set1:\r\n-- 1. Time to rock (01:11)\r\n-- Set Successful");
        }
    }
}
