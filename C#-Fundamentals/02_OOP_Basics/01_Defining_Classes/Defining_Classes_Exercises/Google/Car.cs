public class Car
{
    public string CarModel { get; set; }
    public double CarSpeed { get; set; }

    public override string ToString()
    {
        return $"{CarModel} {CarSpeed}\r\n";
    }
}