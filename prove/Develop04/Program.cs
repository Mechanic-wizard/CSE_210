using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        ActivityLogger.LoadLog();

        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    ActivityLogger.LogActivity("Breathing");
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    ActivityLogger.LogActivity("Reflection");
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    ActivityLogger.LogActivity("Listing");
                    break;
                case "4":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(1500);
                    break;
            }
        }

        ActivityLogger.SaveLog();
        ActivityLogger.DisplayStats();
        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
    }
}