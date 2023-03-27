using Newtonsoft.Json;

namespace Obilet.Common.Clients.Obilet.Dtos.Journey {
	public class JourneysRequestData {

		[JsonProperty("origin-id")]
		public long OriginId { get; set; }

		[JsonProperty("destination-id")]
		public long DestinationId { get; set; }

		[JsonProperty("departure-date")]
		public DateTime DepartureDate { get; set; }

		public JourneysRequestData(long OriginId, long DestinationId, DateTime DepartureDate) {
			
			this.OriginId = OriginId;
			this.DestinationId = DestinationId;
			this.DepartureDate = DepartureDate;
		}

	}
}
