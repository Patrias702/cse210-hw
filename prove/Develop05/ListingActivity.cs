using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    class ListingActivity : Activity
    {
        private string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
        {
            Name = "Listing Activity";
            Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        protected override void PerformActivity()
        {
            Random random = new Random();
            Console.WriteLine(prompts[random.Next(prompts.Length)]);
            ShowSpinner(3); // Pause before starting

            List<string> items = new List<string>();
            int elapsedTime = 0;

            while (elapsedTime < Duration)
            {
                Console.Write("Enter an item: ");
                string item = Console.ReadLine();
                items.Add(item);
                elapsedTime += 5; // Approximating time per entry
            }

            Console.WriteLine($"You listed {items.Count} items.");
        }
    }
}
