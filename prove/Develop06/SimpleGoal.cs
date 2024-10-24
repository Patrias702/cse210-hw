public class SimpleGoal : Goal
{
    private int rewardPoints;

    public SimpleGoal(string name, int rewardPoints) : base(name)
    {
        this.rewardPoints = rewardPoints;
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            Points += rewardPoints;
            IsCompleted = true;
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }

    // This method does not need to override DisplayGoal unless you want custom behavior
    public override void DisplayGoal()
    {
        Console.WriteLine($"[ {(IsCompleted ? "X" : " ")} ] {Name} - Points: {Points}");
    }
}

