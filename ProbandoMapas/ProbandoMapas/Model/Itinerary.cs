using System;

namespace ProbandoMapas.Model
{
    public class Itinerary
    {
        public string Description { get; set; }
        public string OriginAndress { get; set; }
        public string FinalAndress { get; set; }
        public double ItineraryMiles { get; set; }
        public DateTime OriginTime { get; set; }
        public DateTime FinalTime { get; set; }
        public DateTime ItineraryDay { get; set; }
        public int IdItinerario { get; set; }
    }
}
