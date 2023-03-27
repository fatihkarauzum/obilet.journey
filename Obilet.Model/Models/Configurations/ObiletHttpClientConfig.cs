namespace Obilet.Model.Models.Configurations {
	public class ObiletHttpClientConfig
	{

		public string ApiEndPoint { get; set; } = null!;

		public string Accept { get; set; } = null!;

		public AuthorizationConfig Authorization { get; set; } = null!;

	}
}
