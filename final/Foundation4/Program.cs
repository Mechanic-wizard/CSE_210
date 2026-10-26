using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 3.0),
                new Cycling(new DateTime(2022, 11, 4), 45, 18.0),
                new Swimming(new DateTime(2022, 11, 5), 25, 20)
            };

            foreach (Activity act in activities)
            {
                Console.WriteLine(act.GetSummary());
            }
        }
    }
}