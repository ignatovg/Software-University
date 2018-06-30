using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BorderControl
{
    class Human:ICitizen,IRobot,IPet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Birthdate { get; set; }
        
        public string Model { get; set; }
        
        public Human()
        {
            
        }

        public void SetPetData(string name, string birthday)
        {
            this.Name = name;
            this.Birthdate = birthday;
        }

        public void SetCitizenData(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthday;
        }

        public void SetRobotData(string model, string id, string birthday)
        {
            this.Model = model;
            this.Id = id;
            this.Birthdate = birthday;
        }
    }
}
