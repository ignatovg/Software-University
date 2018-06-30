
public class Hard : Mission
{
    private const string nameOfTheMission = "Disposal of terrorists";
    private const double enduranceRequiredConst = 80;
    private const double wearLevelDecrementConst = 70;

    public Hard(double scoreToComplete) : base(scoreToComplete)
    {

    }

    public override string Name => nameOfTheMission;
    public override double EnduranceRequired => enduranceRequiredConst;
    public override double WearLevelDecrement => wearLevelDecrementConst;
}

