using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using Contracts;

    public class Stage : IStage
    {
        //repository
        private List<ISet> sets;
        private List<ISong> songs;
        private List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;
        public IReadOnlyCollection<ISong> Songs => this.songs;
        public IReadOnlyCollection<IPerformer> Performers => this.performers;


        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.Performers.FirstOrDefault(n => n.Name == name);
            return performer;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.Songs.FirstOrDefault(n => n.Name == name);
            return song;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.Sets.FirstOrDefault(n => n.Name == name);
            return set;
        }

        public void AddPerformer(IPerformer performer)
        {
           this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public void AddSet(ISet performer)
        {
          this.sets.Add(performer);
        }

        public bool HasPerformer(string name)
        {
           bool hasePerformer = this.Performers.Any(n=>n.Name == name);
            return hasePerformer;
        }

        public bool HasSong(string name)
        {
            bool hasSong = this.Songs.Any(n => n.Name == name);
            return hasSong;
        }

        public bool HasSet(string name)
        {
            bool hasSet = this.Sets.Any(n => n.Name == name);
            return hasSet;
        }
    }
}
