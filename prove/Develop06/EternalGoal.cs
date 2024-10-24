public class EternalGoal : Goal
{
    private int pointsPerRecord;

    public EternalGoal(string name, int pointsPerRecord) : base(name)
    {
        this.pointsPerRecord = pointsPerRecord;
    }

    public override void RecordEvent()
    {
        Points += pointsPerRecord;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {Name} - Points: {Points} (Eternal Goal)");
    }
}

