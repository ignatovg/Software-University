public abstract class Mission : IMission
{
    protected Mission(double scoreToComplite)
    {
        this.ScoreToComplete = scoreToComplite;
    }

    public abstract string Name { get; }
    public abstract double EnduranceRequired { get; }
    public double ScoreToComplete { get; }
    public abstract double WearLevelDecrement { get; }
}

