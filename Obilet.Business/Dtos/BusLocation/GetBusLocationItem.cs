namespace Obilet.Business.Dtos.BusLocation {
	public class GetBusLocationItem
    {

		public long Id { get; set; }

		public long ParentId { get; set; }

		public string Name { get; set; } = null!;

		public string LongName { get; set; } = null!;

	}
}
