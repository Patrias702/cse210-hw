public class ChecklistGoal : Goal
{
    private int timesToComplete;
    private int bonusPoints;
    private int timesCompleted;

    public ChecklistGoal(string name, int timesToComplete, int pointsPerCompletion, int bonusPoints) : base(name)
    {
        this.timesToComplete = timesToComplete;
        this.Points = pointsPerCompletion;
        this.bonusPoints = bonusPoints;
        this.timesCompleted = 0;
    }

    public override void RecordEvent()
    {
        if (timesCompleted < timesToComplete)
        {
            timesCompleted++;
            Points += Points;
            if (timesCompleted == timesToComplete)
            {
                Points += bonusPoints;
                IsCompleted = true;
            }
        }
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ {(IsCompleted ? "X" : " ")} ] {Name} - Completed {timesCompleted}/{timesToComplete} - Points: {Points}");
    }
}

