
public class Easy:Mission
{
    private const string NameConst = "Suppression of civil rebellion";
    private const double EnduranceRequiredConst = 20;
    private const double WearLevelDecrementConst = 30;

    public Easy(double scoreToComplite) : base(scoreToComplite)
    {
    }

    public override string Name => NameConst;
    public override double EnduranceRequired => EnduranceRequiredConst;
    public override double WearLevelDecrement => WearLevelDecrementConst;

    
}

