using Newtonsoft.Json;

namespace Obilet.Common.Clients.Obilet.Dtos.Session {
	public class SessionData {

		[JsonProperty("session-id")]
		public string SessionId { get; set; } = null!;

		[JsonProperty("device-id")]
		public string DeviceId { get; set; } = null!;

	}
}
