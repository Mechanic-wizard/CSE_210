using System;

namespace EventPlanning
{
    public class Lecture : Event
    {
        private string PB_speaker;
        private int PB_capacity;

        public Lecture(string title, string description, DateTime date, string time, Address address,
                       string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            PB_speaker = speaker;
            PB_capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {PB_speaker}\nCapacity: {PB_capacity}";
        }
    }
}