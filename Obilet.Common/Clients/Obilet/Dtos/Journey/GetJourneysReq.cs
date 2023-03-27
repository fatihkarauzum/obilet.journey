using Newtonsoft.Json;

namespace Obilet.Common.Clients.Obilet.Dtos.Journey {
	public class GetJourneysReq : BaseReq {

		[JsonProperty("data")]
		public JourneysRequestData Data { get; set; }

		public GetJourneysReq(JourneysRequestData Data) {
			this.Data = Data;
		}

	}
}
