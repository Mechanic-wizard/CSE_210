// File: SimpleGoal.cs
namespace EternalQuest
{
    public class PB_SimpleGoal : PB_Goal
    {
        private bool _completed;

        public PB_SimpleGoal(string name, string description, int points, bool completed = false)
            : base(name, description, points)
        {
            _completed = completed;
        }

        public override int RecordEvent()
        {
            if (_completed)
            {
                Console.WriteLine("This goal is already completed.");
                return 0;
            }
            _completed = true;
            return Points;
        }

        public override string Display()
        {
            string status = _completed ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description})";
        }

        public override string GetSaveString()
        {
            return $"PB_SimpleGoal|{Name}|{Description}|{Points}|{_completed}";
        }

        public override bool IsComplete() => _completed;
    }
}