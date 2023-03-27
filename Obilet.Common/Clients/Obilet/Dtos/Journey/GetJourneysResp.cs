using Newtonsoft.Json;
using Obilet.Model.Models.DtoConfigurations;

namespace Obilet.Common.Clients.Obilet.Dtos.Journey {
	public class GetJourneysResp : Response<GetJourneysResp> {

		[JsonProperty("data")]
		public List<JourneyResponseData> Data { get; set; } = new List<JourneyResponseData>();

	}
}
