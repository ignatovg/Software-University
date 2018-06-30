
public class Medium : Mission
{
    private const string nameOfTheMission = "Capturing dangerous criminals";
    private const double enduranceRequiredConst = 50;
    private const double wearLevelDecrementConst = 50;

    public Medium(double scoreToComplete):base(scoreToComplete)
    {
        
    }

    public override string Name => nameOfTheMission;
    public override double EnduranceRequired => enduranceRequiredConst;
    public override double WearLevelDecrement => wearLevelDecrementConst;
}

