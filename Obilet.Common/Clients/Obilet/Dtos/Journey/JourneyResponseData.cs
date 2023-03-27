using Newtonsoft.Json;

namespace Obilet.Common.Clients.Obilet.Dtos.Journey {
	public class JourneyResponseData {

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("partner-name")]
		public string PartnerName { get; set; } = null!;

		[JsonProperty("bus-type-name")]
		public string BusTypeName { get; set; } = null!;

		[JsonProperty("total-seats")]
		public int TotalSeats { get; set; }

		[JsonProperty("available-seats")]
		public int AvaibleSeats { get; set; }

		[JsonProperty("journey")]
		public JourneyData Journey { get; set; } = null!;

	}
}
