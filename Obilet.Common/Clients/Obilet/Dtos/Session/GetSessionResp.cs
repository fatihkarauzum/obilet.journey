using Newtonsoft.Json;
using Obilet.Common.Clients.Obilet.Dtos.Session;
using Obilet.Model.Models.DtoConfigurations;

namespace Obilet.Business.Dtos.Session {

	public class GetSessionResp : Response<GetSessionResp> {

		[JsonProperty("data")]
		public SessionData? Data { get; set; }

	}

}
