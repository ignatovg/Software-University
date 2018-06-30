
using System;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Entities.Sets
{
    public abstract class Set : ISet
    {
        private const string SongIsOverLimit = "Song is over the set limit!";

        private IList<ISong> songs;
        private IList<IPerformer> performers;
        
        protected Set(string name)
        {
            this.Name = name;

            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public string Name { get; }
        public abstract TimeSpan MaxDuration { get; }
        //possible bug

        //  public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

        public TimeSpan ActualDuration => new TimeSpan(0,0,songs.Sum(s=>s.Duration.Minutes),songs.Sum(s=>s.Duration.Seconds));

        public IReadOnlyCollection<IPerformer> Performers { get; }
        public IReadOnlyCollection<ISong> Songs { get; }


        public void AddPerformer(IPerformer performer)
        {
           performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            if (song.Duration > this.MaxDuration)
            {
                throw new InvalidOperationException(SongIsOverLimit);
            }
            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            if (!this.Performers.Any())
            {
                return false;
            }

            if (!this.Songs.Any())
            {
                return false;
            }

            var allPerformersHaveInstruments = this.Performers.All(p => p.Instruments.Any());

            if (!allPerformersHaveInstruments)
            {
                return false;
            }

            var allPerformersHaveFunctioningInstruments = this.performers.All(p => p.Instruments.Any(i => !i.IsBroken));

            if (!allPerformersHaveFunctioningInstruments)
            {
                return false;
            }

            return true;
        }

        
    }
}
