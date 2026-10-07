using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            int remaining = (int)(end - DateTime.Now).TotalSeconds;
            if (remaining <= 0) break;

            int breatheIn = Math.Min(4, remaining);
            Console.Write("Breathe in... ");
            ShowCountDown(breatheIn);
            Console.WriteLine();

            remaining = (int)(end - DateTime.Now).TotalSeconds;
            if (remaining <= 0) break;

            int breatheOut = Math.Min(4, remaining);
            Console.Write("Breathe out... ");
            ShowCountDown(breatheOut);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}