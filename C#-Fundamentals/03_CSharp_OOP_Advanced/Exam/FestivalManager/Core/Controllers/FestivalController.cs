using System.Collections.Generic;
using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private const string RegisterSetSuccsessully = "Registered {0} set";
        private const string SignUpPerformerSuccsessully = "Registered performer {0}";
        private const string RegisterSongSuccessfully = "Registered song {0} ({duration:{1}\\:{2}})";
        private const string InvalidSetProvided = "Invalid set provided";
        private const string InvalidSongProvided = "Invalid song provided";
        private const string AddSongToSetSuccessfully = "Added {0} ({duration:{1}\\:{2}}) to {3}";
        private const string InvalidPerformProvided = "Invalid performer provided";
        private const string AddPerformToSetSuccessfully = "Added {0} to {1}";
        private const string RepairedInstruments = "Repaired {0} instruments";

        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;

        private readonly IStage stage;


        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.setFactory = new SetFactory();
            this.songFactory = new SongFactory();
        }
        

        public string ProduceReport()
        {
            throw new NotImplementedException();
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = setFactory.CreateSet(name, type);

            stage.AddSet(set);
            return string.Format(RegisterSetSuccsessully, type);
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            IPerformer performer = performerFactory.CreatePerformer(name, age);

            var instrumetTypes = args.Skip(2).ToArray();

            //List<IInstrument> instrumetsAsObj = null;

            //foreach (string type in instrumetTypes)
            //{
            //    IInstrument instrument = instrumentFactory.CreateInstrument(type);
            //    instrumetsAsObj.Add(instrument);
            //}

            var instrumenti2 = instrumetTypes
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            foreach (var instrument in instrumenti2)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return string.Format(SignUpPerformerSuccsessully, performer.Name);
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            string[] time = args[1].Split(':').ToArray();
            int minutes = int.Parse(time[0]);
            int seconds = int.Parse(time[1]);

            var duration = new TimeSpan(0, 0, minutes, seconds);

            ISong song = songFactory.CreateSong(name, duration);

            stage.AddSong(song);
            return string.Format($"Registered song {song.Name} ({{duration:{duration.Minutes}\\:{duration.Seconds}}})");
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (stage.Sets.All(n => n.Name != setName))
            {
                throw new InvalidOperationException(InvalidSetProvided);
            }

            if (stage.Songs.All(n => n.Name != songName))
            {
                throw new InvalidOperationException(InvalidSongProvided);
            }

            ISet set = stage.Sets.FirstOrDefault(n=>n.Name == setName);
            ISong song = stage.Songs.FirstOrDefault(n=>n.Name == songName);

            set.AddSong(song);

            return string.Format(AddSongToSetSuccessfully, songName, song.Duration.Minutes, song.Duration.Seconds,
                setName);
        }

        //private string SongRegistration(string[] args)
        //{
        //    var songName = args[0];
        //    var setName = args[1];

        //    if (!this.stage.HasSet(setName))
        //    {
        //        throw new InvalidOperationException("Invalid set provided");
        //    }

        //    if (!this.stage.HasSong(songName))
        //    {
        //        throw new InvalidOperationException("Invalid song provided");
        //    }

        //    var set = this.stage.GetSet(setName);
        //    var song = this.stage.GetSong(songName);

        //    set.AddSong(song);

        //    return $"Added {song} to {set.Name}";
        //}
        
        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            if (stage.Sets.All(n => n.Name != setName))
            {
                throw new InvalidOperationException(InvalidSetProvided);
            }

            if (stage.Performers.All(n => n.Name != performerName))
            {
                throw new InvalidOperationException(InvalidPerformProvided);
            }

            ISet set = stage.Sets.FirstOrDefault(n => n.Name == setName);
            IPerformer performer = stage.Performers.FirstOrDefault(n => n.Name == performerName);

            set.AddPerformer(performer);

            return string.Format(AddPerformToSetSuccessfully, performerName, setName);
        }

        //private string PerformerRegistration(string[] args)
        //{
        //    var performerName = args[0];
        //    var setName = args[1];

        //    if (!this.stage.HasPerformer(performerName))
        //    {
        //        throw new InvalidOperationException("Invalid performer provided");
        //    }

        //    if (!this.stage.HasSet(setName))
        //    {
        //        throw new InvalidOperationException("Invalid set provided");
        //    }

        //    AddPerformerToSet(args);

        //    var performer = this.stage.GetPerformer(performerName);
        //    var set = this.stage.GetSet(setName);

        //    set.AddPerformer(performer);

        //    return $"Added {performer.Name} to {set.Name}";
        //}

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

            return string.Format(RepairedInstruments, instrumentsToRepair.Length);
        }
    }
}