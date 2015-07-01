using System;

namespace ProbandoMapas.Model
{
    public class Itinerary
    {
        public string Description { get; set; }
        public string OriginAdress { get; set; }
        public string FinalAdress { get; set; }
        public double ItineraryMiles { get; set; }
        public DateTime OriginTime { get; set; }
        public DateTime FinalTime { get; set; }
        public DateTime ItineraryDay { get; set; }
    }
}
