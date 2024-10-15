using System;
using System.Threading;

namespace MindfulnessApp
{
    class ReflectionActivity : Activity
    {
        private string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
        {
            Name = "Reflection Activity";
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
        }

        protected override void PerformActivity()
        {
            Random random = new Random();
            Console.WriteLine(prompts[random.Next(prompts.Length)]);
            ShowSpinner(3); // Pause before asking questions

            int elapsedTime = 0;
            while (elapsedTime < Duration)
            {
                Console.WriteLine(questions[random.Next(questions.Length)]);
                ShowSpinner(3); // Pause for reflection
                elapsedTime += 5; // Approximating time for reflection
            }
        }
    }
}
