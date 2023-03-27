using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Obilet.Common.Constants;
using Obilet.Model.Models.DtoConfigurations;
using System.Net.Http.Headers;
using System.Text;

namespace Obilet.Common.Clients.Obilet {
	public class ObiletClient {

		private readonly HttpClient httpClient;
		private readonly ILogger logger;

		private static MediaTypeHeaderValue mediaType = new MediaTypeHeaderValue(MediaTypeConstant.APPLICATION_JSON);

		public ObiletClient(
			HttpClient httpClient,
			ILogger<ObiletClient> logger) {

			this.httpClient = httpClient;
			this.logger = logger;
        }

		public async Task<Resp> PostAsync<Req, Resp>(string endPoint, Req req)
			where Req : Request
			where Resp : Response<Resp>, new() {

			StringContent payload = new StringContent(JsonConvert.SerializeObject(req, Formatting.Indented), Encoding.UTF8, mediaType);
			Resp result = Response<Resp>.EMPTY;

			try {
				using (HttpResponseMessage response = await httpClient.PostAsync(endPoint, payload)) {
					if (!response.IsSuccessStatusCode) {
						result.Message = $$"""An error occurred while accessing the "{{endPoint}}" address. Status code: {{response.StatusCode}}. Reason phrase: {{response.ReasonPhrase}}""";

						return result;
					}

					string respBody = await response.Content.ReadAsStringAsync();
					Resp? resp = JsonConvert.DeserializeObject<Resp>(respBody);

					if (resp != null)
						return resp;
				}

                result.Message = $$"""An error occurred while accessing the "{{endPoint}}" address. Reason phrase: Response is null""";
                logger.LogError(message: result.Message);

                return result;
			}
			catch (Exception ex) {
				result.Message = $$"""An error occurred while accessing the "{{endPoint}}" address. Reason phrase: {{ex.Message}}. Inner Exception: {{ex.InnerException}}""";
                logger.LogError(message: result.Message, exception: ex);

                return result;
			}
		}

	}
}
