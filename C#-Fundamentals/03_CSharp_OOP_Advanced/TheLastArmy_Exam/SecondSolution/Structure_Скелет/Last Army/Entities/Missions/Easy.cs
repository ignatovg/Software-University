public class Easy:Mission
{
    private const string nameOfTheMission = "Suppression of civil rebellion";
    private const double enduranceRequiredConst = 20;
    private const double wearLevelDecrementConst = 30;

    public Easy(double scoreToComplete):base(scoreToComplete)
    {
        
    }

    public override string Name => nameOfTheMission;
    public override double EnduranceRequired => enduranceRequiredConst;
    public override double WearLevelDecrement => wearLevelDecrementConst;
}

