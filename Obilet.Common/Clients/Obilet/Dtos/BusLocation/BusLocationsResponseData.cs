using Newtonsoft.Json;

namespace Obilet.Common.Clients.Obilet.Dtos.BusLocation {
	public class BusLocationsResponseData {

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("parent-id")]
		public long ParentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

		[JsonProperty("long-name")]
		public string LongName { get; set; } = null!;
	}
}
