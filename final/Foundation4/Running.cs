using System;

namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double PB_distance;

        public Running(DateTime date, int lengthMinutes, double distance)
            : base(date, lengthMinutes)
        {
            PB_distance = distance;
        }

        public override double GetDistance() => PB_distance;

        public override double GetSpeed()
        {
            return (PB_distance / LengthMinutes) * 60;
        }

        public override double GetPace()
        {
            return LengthMinutes / PB_distance;
        }
    }
}