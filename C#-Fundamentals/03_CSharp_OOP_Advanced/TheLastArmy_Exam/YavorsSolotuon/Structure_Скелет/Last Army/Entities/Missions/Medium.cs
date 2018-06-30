
public class Medium : Mission
{
    private const string NameConst = "Capturing dangerous criminals";
    private const double EnduranceRequiredConst = 50;
    private const double WearLevelDecrementConst = 50;

    public Medium(double scoreToComplite) : base(scoreToComplite)
    {
    }

    public override string Name => NameConst;
    public override double EnduranceRequired => EnduranceRequiredConst;
    public override double WearLevelDecrement => WearLevelDecrementConst;
}

