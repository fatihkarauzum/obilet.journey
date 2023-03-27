using Newtonsoft.Json;

namespace Obilet.Common.Clients.Obilet.Dtos.BusLocation {
	public class GetBusLocationsReq : BaseReq
    {

		[JsonProperty("data")]
		public string? Data { get; set; }

		public GetBusLocationsReq(string? Data) {
			this.Data = Data;
		}

	}
}
