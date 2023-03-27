namespace Obilet.Business.Dtos.Journey {
	public class GetJourneyItem {

		public long Id { get; set; }

		public string PartnerName { get; set; } = null!;

		public string BusTypeName { get; set; } = null!;

		public int TotalSeats { get; set; }

		public int AvaibleSeats { get; set; }

		public JourneyDetail JourneyDetail { get; set; } = null!;

	}
}
