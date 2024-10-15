using System;
using System.Threading;

namespace MindfulnessApp
{
    class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            Name = "Breathing Activity";
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        protected override void PerformActivity()
        {
            int breatheCycle = 4; // 4 seconds per cycle (in + out)
            int cycles = Duration / breatheCycle;

            for (int i = 0; i < cycles; i++)
            {
                Console.WriteLine("Breathe in...");
                Countdown(2); // Pause for 2 seconds
                Console.WriteLine("Breathe out...");
                Countdown(2); // Pause for 2 seconds
            }
        }
    }
}
