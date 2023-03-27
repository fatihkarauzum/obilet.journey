using Newtonsoft.Json;

namespace Obilet.Common.Clients.Obilet.Dtos.Session {

	public class Browser {

		[JsonProperty("name")]
		public string Name { get; set; } = null!;

		[JsonProperty("version")]
		public string Version { get; set; } = null!;

	}

}
