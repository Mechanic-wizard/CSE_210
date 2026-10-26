using System;
using System.Collections.Generic;

namespace EventPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            Address addr1 = new Address("100 University Ave", "Boston", "MA", "USA");
            Address addr2 = new Address("200 Main St", "Seattle", "WA", "USA");
            Address addr3 = new Address("300 Beach Rd", "Miami", "FL", "USA");

            DateTime date1 = new DateTime(2024, 3, 15);
            DateTime date2 = new DateTime(2024, 4, 20);
            DateTime date3 = new DateTime(2024, 5, 10);

            Lecture lecture = new Lecture("AI Advances", "Latest in AI research", date1, "10:00 AM", addr1,
                                          "Dr. Smith", 150);
            Reception reception = new Reception("Spring Gala", "Annual fundraising gala", date2, "7:00 PM", addr2,
                                                "rsvp@springgala.com");
            OutdoorGathering gathering = new OutdoorGathering("Summer Festival", "Music and food", date3, "12:00 PM", addr3,
                                                             "Sunny, 75°F");

            List<Event> events = new List<Event> { lecture, reception, gathering };

            foreach (Event ev in events)
            {
                Console.WriteLine("--- Standard Details ---");
                Console.WriteLine(ev.GetStandardDetails());
                Console.WriteLine("\n--- Full Details ---");
                Console.WriteLine(ev.GetFullDetails());
                Console.WriteLine("\n--- Short Description ---");
                Console.WriteLine(ev.GetShortDescription());
                Console.WriteLine(new string('=', 40));
            }
        }
    }
}