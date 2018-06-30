using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>) missions;
        public void AddMission(IMission mission)
        {
           missions.Add(mission);
        }

        public void CompliteMissions(string missionCodeName)
        {
            IMission mission = this.Missions.FirstOrDefault(m => m.CodeName == missionCodeName);

            if (mission == null)
            {
                throw new ArgumentException("Mission not found!");
            }
            mission.Complite();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps.ToString()}")
                .AppendLine($"Missions:");

            foreach (var mission in this.Missions)
            {
                builder.AppendLine($"  {mission.ToString()}");
            }
            string result = builder.ToString().TrimEnd();
            return result;
        }
    }
}
