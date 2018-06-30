using System.Linq;
using P04_OnlineRadioDatabase;

class Song
{
    private string artistName;
    private string songName;

    private int minutes;
    private int seconds;

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            artistName = value;
        }
    }

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }
            songName = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            seconds = value;
        }
    }

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    private void CalculateMinutesAndValidate(string lenght)
    {
        string[] tokens = lenght.Split(':');
        int totalMinutes = int.Parse(tokens[0]);
        int totalSeonds = int.Parse(tokens[1]);

        int second = 0;

        while (totalSeonds >= 60)
        {
          
            if (totalSeonds >= 60)
            {
                totalMinutes += totalSeonds / 60;
                totalSeonds = totalSeonds % 60;
            }
        }
       ValidateLenght(totalMinutes, totalSeonds);
    }

    private void ValidateLenght(int minutes, int seconds)
    {
        //todo test it!
        if (minutes < 0 || seconds < 0)
        {
            throw new InvalidSongLengthException();
        }
        if (minutes > 14 || seconds > 59)
        {
            throw new InvalidSongLengthException();
        }
    }




}
