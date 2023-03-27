namespace Obilet.Common.Dtos {
	public class HttpUserAgentInfo {

		public static HttpUserAgentInfo EMPTY = new HttpUserAgentInfo();

		public bool isEmpty() {
			return EMPTY.Equals(this);
		}

		public bool isNotEmpty() {
			return !EMPTY.Equals(this);
		}

		public string? BrowserName { get; set; }

		public string? BrowserVersion { get; set; }

		public HttpUserAgentInfo() {}

		public HttpUserAgentInfo(string browserName, string browserVersion) {

			this.BrowserName = browserName;
			this.BrowserVersion = browserVersion;
		}

	}
}
