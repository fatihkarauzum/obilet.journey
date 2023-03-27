namespace Obilet.Journey.Models.ParameterModels {
    public class SearchJourneyParamModel {

        public long OriginId { get; set; }

        public string OriginName { get; set; } = null!;

        public long DestinationId { get; set; }

        public string DestinationName { get; set; } = null!;

        public DateTime DepartureDate { get; set; }

    }
}
