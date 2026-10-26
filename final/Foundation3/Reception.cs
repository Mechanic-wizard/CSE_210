using System;

namespace EventPlanning
{
    public class Reception : Event
    {
        private string PB_rsvpEmail;

        public Reception(string title, string description, DateTime date, string time, Address address,
                         string rsvpEmail)
            : base(title, description, date, time, address)
        {
            PB_rsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nEvent Type: Reception\nRSVP Email: {PB_rsvpEmail}";
        }
    }
}