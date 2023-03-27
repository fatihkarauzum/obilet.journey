using Obilet.Business.Dtos.Journey;

namespace Obilet.Journey.Models.ViewModels
{
    public class JourneysViewModel
    {

        public List<GetJourneyItem> Journeys { get; set; }

        public string OriginName { get; set; } = null!;

        public string DestinationName { get; set; } = null!;

        public DateTime DepartureDate { get; set; }

    }
}
