using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectionActivity()
        : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {prompt} --- ");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        // Shuffle questions so none are repeated until all used this run
        List<string> shuffled = new List<string>(_questions);
        Shuffle(shuffled);
        int idx = 0;
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            string q = shuffled[idx];
            Console.Write($"> {q} ");
            int remaining = (int)(end - DateTime.Now).TotalSeconds;
            if (remaining <= 0) break;
            int pause = Math.Min(5, remaining);
            ShowSpinner(pause);
            Console.WriteLine();

            idx++;
            if (idx >= shuffled.Count)
            {
                Shuffle(shuffled);
                idx = 0;
            }
        }
        DisplayEndingMessage();
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}