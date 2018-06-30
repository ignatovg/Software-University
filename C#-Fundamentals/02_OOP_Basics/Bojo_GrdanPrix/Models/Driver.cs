public abstract class Driver
{
    protected Driver(string name, Car car, double fuelConsumption)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumption;
        this.TotalTime = 0d;
    }

    public string Name { get; }

    public double TotalTime { get; set; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public string FailureReason { get;private set; }
    public bool IsRacing { get; set; }

    private string Status => IsRacing ? this.TotalTime.ToString() : this.FailureReason;

    private void Box()
    {
        this.TotalTime += 20;
    }

    public void Refuel(string[] methodArgs)
    {
        this.Box();
        double fuelAmount = double.Parse(methodArgs[0]);

        this.Car.Refuel(fuelAmount);
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Box();
        this.Car.ChangeTyres(tyre);
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }


    public void CompliteLap(double trackLenght)
    {
        this.TotalTime += 60 / (trackLenght / this.Speed);

        this.Car.CompleteLap(trackLenght,this.FuelConsumptionPerKm);
    }

    public void Fail(string aeMessage)
    {
        this.IsRacing = false;
        this.FailureReason = aeMessage;
    }

    //public void Overtake(double seconds, bool isOvertaking)
    //{
    //    this.TotalTime += isOvertaking ? seconds : -seconds;
    //}
}

