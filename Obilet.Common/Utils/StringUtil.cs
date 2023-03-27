namespace Obilet.Common.Utils {

	public static class StringUtil {

		public static bool IsNullOrEmpty(this string value)
		=> value == null || string.IsNullOrEmpty(value?.Trim());

		public static bool IsNotNullOrEmpty(this String value)
			=> value != null && !string.IsNullOrEmpty(value);

	}

}
