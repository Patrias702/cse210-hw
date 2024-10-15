using System;
using System.Threading;

namespace MindfulnessApp
{
    abstract class Activity
    {
        protected string Name;
        protected string Description;
        protected int Duration;

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name}");
            Console.WriteLine(Description);
            Console.Write("Enter the duration (in seconds): ");
            Duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3); // Pause before starting

            PerformActivity();

            Console.WriteLine($"You have completed the {Name} for {Duration} seconds.");
            ShowSpinner(3);
        }

        protected abstract void PerformActivity();

        protected void ShowSpinner(int duration)
        {
            for (int i = 0; i < duration; i++)
            {
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b-");
                Thread.Sleep(250);
                Console.Write("\b\\");
                Thread.Sleep(250);
                Console.Write("\b|");
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
