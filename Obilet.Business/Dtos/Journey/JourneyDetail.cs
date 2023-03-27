namespace Obilet.Business.Dtos.Journey {
	public class JourneyDetail {

		public string Kind { get; set; } = null!;

		public string Origin { get; set; } = null!;

		public string Destination { get; set; } = null!;

		public DateTime Departure { get; set; }

		public DateTime Arrival { get; set; }

		public string Currency { get; set; } = null!;

		public string Duration { get; set; } = null!;

		public double OriginalPrice { get; set; }

	}
}
