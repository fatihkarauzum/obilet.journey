using Newtonsoft.Json;
using Obilet.Common.Clients.Obilet.Dtos.Session;
using Obilet.Model.Models.DtoConfigurations;

namespace Obilet.Common.Clients.Obilet.Dtos {
	public class BaseReq : Request {

		[JsonProperty("device-session")]
		public SessionData DeviceSession { get; set; } = new SessionData();

		[JsonProperty("language")]
		public string Language { get; set; } = "tr-TR";

		[JsonProperty("date")]
		public DateTime Date { get; set; } = DateTime.Now;

	}
}
