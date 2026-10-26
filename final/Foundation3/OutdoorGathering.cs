using System;

namespace EventPlanning
{
    public class OutdoorGathering : Event
    {
        private string PB_weatherForecast;

        public OutdoorGathering(string title, string description, DateTime date, string time, Address address,
                                string weatherForecast)
            : base(title, description, date, time, address)
        {
            PB_weatherForecast = weatherForecast;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nEvent Type: Outdoor Gathering\nWeather Forecast: {PB_weatherForecast}";
        }
    }
}