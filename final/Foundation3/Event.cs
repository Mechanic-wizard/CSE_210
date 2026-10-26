using System;

namespace EventPlanning
{
    public abstract class Event
    {
        private string PB_title;
        private string PB_description;
        private DateTime PB_date;
        private string PB_time;
        private Address PB_address;

        public Event(string title, string description, DateTime date, string time, Address address)
        {
            PB_title = title;
            PB_description = description;
            PB_date = date;
            PB_time = time;
            PB_address = address;
        }

        public string GetStandardDetails()
        {
            return $"Title: {PB_title}\nDescription: {PB_description}\nDate: {PB_date.ToShortDateString()}\nTime: {PB_time}\nAddress: {PB_address.GetFullAddress()}";
        }

        public abstract string GetFullDetails();

        public string GetShortDescription()
        {
            string eventType = this.GetType().Name;
            return $"Event Type: {eventType}\nTitle: {PB_title}\nDate: {PB_date.ToShortDateString()}";
        }
    }
}