// File: EternalGoal.cs
namespace EternalQuest
{
    public class PB_EternalGoal : PB_Goal
    {
        public PB_EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override int RecordEvent()
        {
            return Points;
        }

        public override string Display()
        {
            return $"[∞] {Name} ({Description})";
        }

        public override string GetSaveString()
        {
            return $"PB_EternalGoal|{Name}|{Description}|{Points}";
        }

        public override bool IsComplete() => false;
    }
}