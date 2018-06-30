using System;
using System.Collections.Generic;
using System.Text;
using P08_MilitaryElite.Contracts;

namespace P08_MilitaryElite
{
public class Mission:IMission
    {
        public Mission(string codeName,string missionState)
        {
            this.CodeName = codeName;
            ParseMissonsState(missionState);
        }

        private void ParseMissonsState(string missionState)
        {
            bool validState = Enum.TryParse(typeof(MissionState), missionState, out object outState);

            if (!validState)
            {
                throw new ArgumentException("Invalid state!");
            }
            this.State = (MissionState) outState;
        }

        public string CodeName { get; private set; }
        public MissionState State { get; private set; }

        public void Complite()
        {
            if (this.State == MissionState.Finished)
            {
                throw  new InvalidOperationException("Mission already finished!");
            }
            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State.ToString()}";
        }
    }
}
