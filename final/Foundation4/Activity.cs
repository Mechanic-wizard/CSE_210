using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime PB_date;
        private int PB_lengthMinutes;

        public Activity(DateTime date, int lengthMinutes)
        {
            PB_date = date;
            PB_lengthMinutes = lengthMinutes;
        }

        public DateTime Date => PB_date;
        public int LengthMinutes => PB_lengthMinutes;

        public abstract double GetDistance(); // miles
        public abstract double GetSpeed();    // mph
        public abstract double GetPace();     // minutes per mile

        public virtual string GetSummary()
        {
            return $"{PB_date:dd MMM yyyy} {GetType().Name} ({PB_lengthMinutes} min) - " +
                   $"Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, " +
                   $"Pace: {GetPace():0.0} min per mile";
        }
    }
}