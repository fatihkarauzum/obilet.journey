using Newtonsoft.Json;
using Obilet.Model.Models.DtoConfigurations;

namespace Obilet.Common.Clients.Obilet.Dtos.BusLocation {
    public class GetBusLocationsResp : Response<GetBusLocationsResp>
    {

		[JsonProperty("data")]
		public List<BusLocationsResponseData> Data { get; set; } = new List<BusLocationsResponseData>();

    }
}
