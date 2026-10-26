using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double PB_speed;

        public Cycling(DateTime date, int lengthMinutes, double speed)
            : base(date, lengthMinutes)
        {
            PB_speed = speed;
        }

        public override double GetDistance()
        {
            return PB_speed * (LengthMinutes / 60.0);
        }

        public override double GetSpeed() => PB_speed;

        public override double GetPace()
        {
            return 60.0 / PB_speed;
        }
    }
}