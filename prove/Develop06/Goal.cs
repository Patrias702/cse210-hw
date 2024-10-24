public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name)
    {
        Name = name;
        Points = 0;
        IsCompleted = false;
    }

    // Abstract method to record an event, must be implemented by derived classes
    public abstract void RecordEvent();

    // Virtual method that can be overridden by derived classes, but not required
    public virtual void DisplayGoal()
    {
        Console.WriteLine($"{Name} - Points: {Points}");
    }

    // Virtual method to get points, can be overridden if needed
    public virtual int GetPoints()
    {
        return Points;
    }
}



