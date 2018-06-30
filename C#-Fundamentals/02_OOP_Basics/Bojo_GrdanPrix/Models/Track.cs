public class Track
{
    private Weather weather;

    public Track(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
        this.Weather = Weather.Sunny;
        this.CurrentLab = 0;
    }
    
    public Weather Weather
    {
        get { return weather; }
        set { weather = value; }
    }

    public int LapsNumber { get; }

    public int TrackLength { get; }

    public int CurrentLab { get; set; }
}

