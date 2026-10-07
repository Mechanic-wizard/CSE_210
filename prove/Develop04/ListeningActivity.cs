using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
        : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("List as many responses you can to the following prompt:");
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($" --- {prompt} --- ");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> items = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }

        Console.WriteLine($"You listed {items.Count} items!");
        DisplayEndingMessage();
    }
}