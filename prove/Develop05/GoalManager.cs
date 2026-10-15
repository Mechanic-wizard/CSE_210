// File: GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class PB_GoalManager
    {
        private List<PB_Goal> _goals = new List<PB_Goal>();
        private int _score;
        private int _level;

        public int Score => _score;
        public int Level => _level;

        public PB_GoalManager()
        {
            _score = 0;
            _level = 1;
        }

        public void AddGoal(PB_Goal goal)
        {
            _goals.Add(goal);
        }

        public void RecordEvent(int goalIndex)
        {
            if (goalIndex < 0 || goalIndex >= _goals.Count)
            {
                Console.WriteLine("Invalid goal index.");
                return;
            }
            PB_Goal goal = _goals[goalIndex];
            int pointsEarned = goal.RecordEvent();
            if (pointsEarned != 0)
            {
                _score += pointsEarned;
                Console.WriteLine($"You earned {pointsEarned} points! Total score: {_score}");
                UpdateLevel();
            }
            else
            {
                Console.WriteLine("No points earned.");
            }
        }

        private void UpdateLevel()
        {
            int newLevel;
            if (_score < 100) newLevel = 1;
            else if (_score < 500) newLevel = 2;
            else if (_score < 2000) newLevel = 3;
            else if (_score < 5000) newLevel = 4;
            else newLevel = 5;

            if (newLevel > _level)
            {
                _level = newLevel;
                string title = GetLevelTitle(_level);
                Console.WriteLine($"🎉 Congratulations! You've reached level {_level} - {title}! 🎉");
            }
        }

        private string GetLevelTitle(int level)
        {
            switch (level)
            {
                case 1: return "Novice";
                case 2: return "Apprentice";
                case 3: return "Journeyman";
                case 4: return "Master";
                case 5: return "Grand Master";
                default: return "Legend";
            }
        }

        public void DisplayGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available.");
                return;
            }
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].Display()}");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Current Score: {_score}");
            string title = GetLevelTitle(_level);
            Console.WriteLine($"Level: {_level} - {title}");
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                writer.WriteLine(_level);
                foreach (PB_Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetSaveString());
                }
            }
            Console.WriteLine($"Goals saved to {filename}");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }
            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine());
                _level = int.Parse(reader.ReadLine());
                _goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    PB_Goal goal = PB_Goal.LoadFromString(line);
                    _goals.Add(goal);
                }
            }
            Console.WriteLine($"Goals loaded from {filename}");
        }

        public List<PB_Goal> GetGoals() => _goals;
    }
}