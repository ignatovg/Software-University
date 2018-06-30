
using System;
using System.Linq;
using System.Text;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Core
{
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using IO.Contracts;

    /// <summary>
    /// by g0shk0
    /// </summary>
    public class Engine : IEngine
    {
        private const string ErrorMessage = "ERROR: {0}";
        private const string FestivalLenght = "Festival length: {0}";
        private const string SetsAndActualDuration = "--{0} ({1}):";
        private const string PerformerNameAndInstruments = "---{0} ({1})";
        private const string NoSongsPlayed = "--No songs played";
        private const string SongsPlayed = "--Songs played:";
        private const string SongNameAndDuration = "----{0} ({songDuration:{1}\\:{2}})";


        private IReader reader;
        private IWriter writer;
        private IStage stage;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;


        public Engine(IWriter writer, IReader reader, IFestivalController festivalController, ISetController setController,IStage stage)
        {
            this.writer = writer;
            this.reader = reader;
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
            this.stage = stage;
        }

        //// дайгаз
        //public void Запали()
        //{
        //	while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) // for job security
        //	{
        //		var input = chetach.ReadLine();

        //		if (input == "END")
        //			break;

        //		try
        //		{
        //			string.Intern(input);

        //			var result = this.DoCommand(input);
        //			this.pisach.WriteLine(result);
        //		}
        //		catch (Exception ex) // in case we run out of memory
        //		{
        //			this.pisach.WriteLine("ERROR: " + ex.Message);
        //		}
        //	}

        //	var end = this.festivalController.Report();

        //	this.pisach.WriteLine("Results:");
        //	this.pisach.WriteLine(end);
        //}

        //public string DoCommand(string input)
        //{
        //    var chasti = input.Split(" ".ToCharArray().First());

        //    var purvoto = chasti.First();
        //    var parametri = chasti.Skip(1).ToArray();

        //    if (purvoto == "LetsRock")
        //    {
        //        var setovete = this.setController.PerformSets();
        //        return setovete;
        //    }

        //    var festivalcontrolfunction = this.festivalController.GetType()
        //        .GetMethods()
        //        .FirstOrDefault(x => x.Name == purvoto);

        //    string a;

        //    try
        //    {
        //        a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parametri });
        //    }
        //    catch (TargetInvocationException up)
        //    {
        //        throw up; // ha ha
        //    }

        //    return a;
        //}

        public void Run()
        {
            var input = reader.ReadLine();

            while (!input.Equals("END"))
            {
                writer.WriteLine(ProcessCommand(input));

                input = reader.ReadLine();
            }
            writer.WriteLine(Report());
        }

        public string ProcessCommand(string input)
        {
            var data = input.Split();
            var args = data.Skip(1).ToArray();

            var sb = new StringBuilder();

            if (data[0].Equals("RegisterSet"))
            {
                try
                {
                    sb.AppendLine(festivalCоntroller.RegisterSet(args));
                }
                catch (Exception e)
                {
                    sb.AppendLine(string.Format(ErrorMessage, e.Message));
                }
            }
            else if (data[0] == "SignUpPerformer")
            {
                try
                {
                    sb.AppendLine(festivalCоntroller.SignUpPerformer(args));
                }
                catch (Exception e)
                {
                    sb.AppendLine(string.Format(ErrorMessage, e.Message));
                }
            }

            else if (data[0].Equals("RegisterSong"))
            {
                try
                {
                    sb.AppendLine(festivalCоntroller.RegisterSong(args));
                }
                catch (Exception e)
                {
                    sb.AppendLine(string.Format(ErrorMessage, e.Message));
                }
            }
            else if (data[0].Equals("AddSongToSet"))
            {
                try
                {
                    sb.AppendLine(festivalCоntroller.AddSongToSet(args));
                }
                catch (Exception e)
                {
                    sb.AppendLine(string.Format(ErrorMessage, e.Message));
                }
            }
            else if (data[0].Equals("AddPerformerToSet"))
            {
                try
                {
                    sb.AppendLine(festivalCоntroller.AddPerformerToSet(args));
                }
                catch (Exception e)
                {
                    sb.AppendLine(string.Format(ErrorMessage, e.Message));
                }
            }
            else if (data[0].Equals("RepairInstruments"))
            {
                try
                {
                    sb.AppendLine(festivalCоntroller.RepairInstruments(args));
                }
                catch (Exception e)
                {
                    sb.AppendLine(string.Format(ErrorMessage, e.Message));
                    throw;
                }
            }
            else if (data[0].Equals("LetsRock"))
            {
                sb.AppendLine(setCоntroller.PerformSets());
            }

            return sb.ToString().TrimEnd();
        }

        private string Report()
        {
            var result = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result.AppendLine(string.Format(FestivalLenght, totalFestivalLength));

            foreach (var set in this.stage.Sets)
            {
                //result.AppendLine($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

                result.AppendLine(string.Format(SetsAndActualDuration, set.Name, set.ActualDuration));

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result.AppendLine(string.Format(PerformerNameAndInstruments,performer.Name,instruments));
                }

                if (!set.Songs.Any())
                {
                    result.AppendLine(NoSongsPlayed);
                }
                else
                {
                    result.AppendLine(SongsPlayed);
                    foreach (var song in set.Songs)
                    {
                        result.AppendLine(string.Format(SongNameAndDuration, song.Name, song.Duration.Minutes,
                            song.Duration.Seconds));
                    }
                }
            }

            return result.ToString();
        }
    }
}