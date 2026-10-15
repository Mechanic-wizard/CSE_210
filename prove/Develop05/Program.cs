// File: Program.cs
using System;
using System.Collections.Generic;

namespace EternalQuest
{
    class PB_Program
    {
        static void Main(string[] args)
        {
            PB_GoalManager manager = new PB_GoalManager();
            bool running = true;
            string filename = "goals.txt";

            while (running)
            {
                Console.WriteLine("\n=== Eternal Quest Menu ===");
                manager.DisplayScore();
                Console.WriteLine("\n1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event (Complete a goal)");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Quit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateGoal(manager);
                        break;
                    case "2":
                        manager.DisplayGoals();
                        break;
                    case "3":
                        RecordEvent(manager);
                        break;
                    case "4":
                        manager.Save(filename);
                        break;
                    case "5":
                        manager.Load(filename);
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Good luck on your Eternal Quest!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateGoal(PB_GoalManager manager)
        {
            Console.WriteLine("\nTypes of Goals:");
            Console.WriteLine("1. Simple Goal (complete once)");
            Console.WriteLine("2. Eternal Goal (never complete, repeatable)");
            Console.WriteLine("3. Checklist Goal (must be done multiple times)");
            Console.WriteLine("4. Negative Goal (bad habit - subtracts points, complete once)");
            Console.Write("Select goal type: ");
            string type = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points value: ");
            int points = int.Parse(Console.ReadLine());

            PB_Goal goal = null;
            switch (type)
            {
                case "1":
                    goal = new PB_SimpleGoal(name, description, points);
                    break;
                case "2":
                    goal = new PB_EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points for completion: ");
                    int bonus = int.Parse(Console.ReadLine());
                    goal = new PB_ChecklistGoal(name, description, points, target, bonus);
                    break;
                case "4":
                    goal = new PB_NegativeGoal(name, description, points);
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    return;
            }
            manager.AddGoal(goal);
            Console.WriteLine("Goal created successfully!");
        }

        static void RecordEvent(PB_GoalManager manager)
        {
            List<PB_Goal> goals = manager.GetGoals();
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals to record.");
                return;
            }
            Console.WriteLine("\nSelect a goal to record:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Display()}");
            }
            Console.Write("Enter goal number: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                manager.RecordEvent(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}