// File: NegativeGoal.cs
namespace EternalQuest
{
    // Negative Goal: subtracts points when recorded (bad habit)
    public class PB_NegativeGoal : PB_Goal
    {
        private bool _completed;

        public PB_NegativeGoal(string name, string description, int points, bool completed = false)
            : base(name, description, points)
        {
            _completed = completed;
        }

        public override int RecordEvent()
        {
            if (_completed)
            {
                Console.WriteLine("You've already broken this habit once; it's now complete.");
                return 0;
            }
            _completed = true;
            return -Points; // subtract points
        }

        public override string Display()
        {
            string status = _completed ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description}) [Negative Goal]";
        }

        public override string GetSaveString()
        {
            return $"PB_NegativeGoal|{Name}|{Description}|{Points}|{_completed}";
        }

        public override bool IsComplete() => _completed;
    }
}