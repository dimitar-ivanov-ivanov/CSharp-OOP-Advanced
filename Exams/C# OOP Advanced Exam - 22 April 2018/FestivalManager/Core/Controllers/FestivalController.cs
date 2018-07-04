namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController  : IFestivalController
    {
        private IStage stage;
        private IInstrumentFactory instrumentFactory;
        private ISetFactory setFactory;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.setFactory = new SetFactory();
        }

        public string ProduceReport()
        {
            var result = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result.AppendLine("Festival length: " + GetOutputTime(totalFestivalLength));

            foreach (var set in this.stage.Sets)
            {
                result.AppendLine($"--{set.Name} ({GetOutputTime(set.ActualDuration)}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                    result.AppendLine("--No songs played");
                else
                {
                    result.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        result.AppendLine($"----{song.ToString()})");
                    }
                }
            }

            return result.ToString().TrimEnd();
        }

        private string GetOutputTime(TimeSpan timeSpan)
        {
            var mins = (timeSpan.Hours * 60 + timeSpan.Minutes).ToString();
            var seconds = timeSpan.Seconds.ToString();

            var minsStr = mins.PadLeft(2, '0');
            var secondsStr = seconds.PadLeft(2, '0');

            return $"{minsStr}:{secondsStr}";
        }

        public string RegisterSet(string[] args)
        {
            var name = args[0];
            var type = args[1];
            var set = setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return $"Registered {type} set";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instruments = args
                .Skip(2)
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = new Performer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            var name = args[0];
            //Leading zeros?

            var time = args[1].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var min = int.Parse(time[0]);
            var seconds = int.Parse(time[1]);

            var timeSpan = new TimeSpan(0, min, seconds);

            var song = new Song(name, timeSpan);

            stage.AddSong(song);

            return $"Registered song {song}";
        }

        public string AddPerformerToSet(string[] args)
        {
            return this.PerformerRegistration(args);
        }

        private string PerformerRegistration(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string AddSongToSet(string[] args)
        {
            return SongRegistration(args);
        }

        private string SongRegistration(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }
    }
}