// File: Goal.cs
using System;

namespace EternalQuest
{
    public abstract class PB_Goal
    {
        private string _name;
        private string _description;
        private int _points;

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;

        public PB_Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        public abstract int RecordEvent();
        public abstract string Display();
        public abstract string GetSaveString();

        public virtual bool IsComplete() => false;

        // Factory method to load a goal from a save line
        public static PB_Goal LoadFromString(string line)
        {
            string[] parts = line.Split('|');
            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            switch (type)
            {
                case "PB_SimpleGoal":
                    bool completed = bool.Parse(parts[4]);
                    return new PB_SimpleGoal(name, description, points, completed);
                case "PB_EternalGoal":
                    return new PB_EternalGoal(name, description, points);
                case "PB_ChecklistGoal":
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int current = int.Parse(parts[6]);
                    return new PB_ChecklistGoal(name, description, points, target, bonus, current);
                case "PB_NegativeGoal":
                    bool negCompleted = bool.Parse(parts[4]);
                    return new PB_NegativeGoal(name, description, points, negCompleted);
                default:
                    throw new Exception("Unknown goal type");
            }
        }
    }
}