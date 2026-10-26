using System;

namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int PB_laps;

        public Swimming(DateTime date, int lengthMinutes, int laps)
            : base(date, lengthMinutes)
        {
            PB_laps = laps;
        }

        public override double GetDistance()
        {
            return PB_laps * 50.0 / 1000.0 * 0.62;
        }

        public override double GetSpeed()
        {
            double dist = GetDistance();
            return (dist / LengthMinutes) * 60;
        }

        public override double GetPace()
        {
            double dist = GetDistance();
            return LengthMinutes / dist;
        }
    }
}