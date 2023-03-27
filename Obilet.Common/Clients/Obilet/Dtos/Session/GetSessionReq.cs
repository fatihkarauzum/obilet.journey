using Newtonsoft.Json;
using Obilet.Common.Clients.Obilet.Dtos.Session;
using Obilet.Model.Models;
using Obilet.Model.Models.DtoConfigurations;

namespace Obilet.Business.Dtos.Session {

	public class GetSessionReq : Request {

		[JsonProperty("type")]
		public DeviceType DeviceType { get; set; } = DeviceType.DEFAULT;

		[JsonProperty("connection")]
		public Connection Connection { get; set; } = null!;

		[JsonProperty("browser")]
		public Browser Browser { get; set; } = null!;

		public GetSessionReq(Connection connection, Browser browser) {

			this.Connection = connection;
			this.Browser = browser;
		}

	}

}
