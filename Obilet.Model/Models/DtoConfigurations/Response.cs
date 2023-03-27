using Newtonsoft.Json;

namespace Obilet.Model.Models.DtoConfigurations {

	public abstract class Response<T>
		where T : class, new() {

		public static T EMPTY = new T();

		public bool isEmpty() {
			return EMPTY.Equals(this);
		}

		public bool isNotEmpty() {
			return !EMPTY.Equals(this);
		}

		public bool isValid() {
			return "Success".Equals(Status);
		}

		[JsonProperty("status")]
		public string? Status { get; set; } = "Failed";

		[JsonProperty("message")]
		public string? Message { get; set; }

		[JsonProperty("user-message")]
		public string? UserMessage { get; set; }

	}

}
