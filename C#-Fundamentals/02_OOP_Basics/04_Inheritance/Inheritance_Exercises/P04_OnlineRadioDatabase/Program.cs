using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> database = new List<Song>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().ToLower().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                try
                {
                    string[] time = input[2].Split(':').ToArray();
                    int digit1;
                    int digit2;
                    if (int.TryParse(time[0], out digit1) && int.TryParse(time[1], out digit2))
                    {
                        database.Add(new Song(input[0], input[1], digit1, digit2));
                        Console.WriteLine("Song added.");
                    }
                    else
                    {
                        throw new InvalidSongLengthException();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Songs added: {database.Count}");
            int totalDuration = 0;
            foreach (var song in database)
            {
                totalDuration += song.Minutes * 60 + song.Seconds;
            }
            int hours = totalDuration / 3600;
            totalDuration -= hours * 3600;
            int minutes = totalDuration / 60;
            totalDuration -= minutes * 60;
            int seconds = totalDuration;

            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
        }
    }
}
