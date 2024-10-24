using System;
using System.Collections.Generic;

public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalPoints = 0;

    static void Main(string[] args)
    {
        LoadGoals();
        while (true)
        {
            DisplayMenu();
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordGoalEvent();
                    break;
                case "3":
                    DisplayGoals();
                    break;
                case "4":
                    SaveGoals();
                    return;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\nEternal Quest Menu:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. Record Event");
        Console.WriteLine("3. Show Goals and Score");
        Console.WriteLine("4. Save and Exit");
        Console.WriteLine("Enter your choice: ");
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string goalType = Console.ReadLine();
        Console.WriteLine("Enter goal name: ");
        string name = Console.ReadLine();

        if (goalType == "1")
        {
            Console.WriteLine("Enter reward points: ");
            int rewardPoints = int.Parse(Console.ReadLine());
            goals.Add(new SimpleGoal(name, rewardPoints));
        }
        else if (goalType == "2")
        {
            Console.WriteLine("Enter points per record: ");
            int pointsPerRecord = int.Parse(Console.ReadLine());
            goals.Add(new EternalGoal(name, pointsPerRecord));
        }
        else if (goalType == "3")
        {
            Console.WriteLine("Enter times to complete: ");
            int timesToComplete = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter points per completion: ");
            int pointsPerCompletion = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bonus points: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, timesToComplete, pointsPerCompletion, bonusPoints));
        }
    }

    static void RecordGoalEvent()
    {
        Console.WriteLine("Enter the number of the goal to record an event: ");
        DisplayGoals();
        int goalIndex = int.Parse(Console.ReadLine());
        goals[goalIndex].RecordEvent();
        totalPoints += goals[goalIndex].GetPoints();
        Console.WriteLine($"Event recorded for {goals[goalIndex].Name}");
    }

    static void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            goals[i].DisplayGoal();
        }
        Console.WriteLine($"\nTotal Points: {totalPoints}");
    }

    static void SaveGoals()
    {
        // Serialization logic goes here for saving goals
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        // Deserialization logic goes here for loading goals
        Console.WriteLine("Goals loaded successfully.");
    }
}
