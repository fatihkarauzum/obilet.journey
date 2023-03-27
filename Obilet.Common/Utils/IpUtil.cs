using System.Text.RegularExpressions;

namespace Obilet.Common.Utils {
    public static partial class IpUtil {

        private static string realIp { get; set; } = null!;

        private static HttpClient client = new HttpClient();

        private const string CHECKIP_URL = "https://checkip.amazonaws.com";

        public static async Task<string> ResolveRealIp() {

			if (realIp.IsNotNullOrEmpty())
				return realIp;


            try {
                using (HttpResponseMessage response = await client.GetAsync(CHECKIP_URL)) {
                    if (!response.IsSuccessStatusCode)
                        return "";

                    string dnsString = await response.Content.ReadAsStringAsync();
                    dnsString = DnsStringRegex().Match(dnsString).Value;

                    return dnsString;
                }
            }
            catch (Exception) {
                return "";
            }
		
		}

		[GeneratedRegex("\\b\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\b")]
		private static partial Regex DnsStringRegex();

	}
}
