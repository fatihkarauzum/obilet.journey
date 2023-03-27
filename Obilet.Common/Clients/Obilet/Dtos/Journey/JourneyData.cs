using Newtonsoft.Json;

namespace Obilet.Common.Clients.Obilet.Dtos.Journey {
	public class JourneyData {

		[JsonProperty("kind")]
		public string Kind { get; set; } = null!;

		[JsonProperty("origin")]
		public string Origin { get; set; } = null!;

		[JsonProperty("destination")]
		public string Destination { get; set; } = null!;

		[JsonProperty("departure")]
		public DateTime Departure { get; set; }

		[JsonProperty("arrival")]
		public DateTime Arrival { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; } = null!;

		[JsonProperty("duration")]
		public string Duration { get; set; } = null!;

		[JsonProperty("original-price")]
		public double OriginalPrice { get; set; }

	}
}
