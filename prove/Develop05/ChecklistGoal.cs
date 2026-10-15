// File: ChecklistGoal.cs
namespace EternalQuest
{
    public class PB_ChecklistGoal : PB_Goal
    {
        private int _targetCount;
        private int _bonusPoints;
        private int _currentCount;

        public PB_ChecklistGoal(string name, string description, int points, int target, int bonus, int current = 0)
            : base(name, description, points)
        {
            _targetCount = target;
            _bonusPoints = bonus;
            _currentCount = current;
        }

        public override int RecordEvent()
        {
            if (_currentCount >= _targetCount)
            {
                Console.WriteLine("This goal is already complete.");
                return 0;
            }
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                return Points + _bonusPoints;
            }
            return Points;
        }

        public override string Display()
        {
            string status = _currentCount >= _targetCount ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description}) -- Completed {_currentCount}/{_targetCount}";
        }

        public override string GetSaveString()
        {
            return $"PB_ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonusPoints}|{_currentCount}";
        }

        public override bool IsComplete() => _currentCount >= _targetCount;
    }
}