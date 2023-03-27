using Newtonsoft.Json;

namespace Obilet.Common.Clients.Obilet.Dtos.Session {

	public class Connection {

		[JsonProperty("ip-address")]
		public string IpAddress { get; set; } = null!;

		[JsonProperty("port")]
		public string Port { get; set; } = null!;

		public Connection(string ipAddress, string port) {

			this.IpAddress = ipAddress;
			this.Port = port;
		}

	}

}
