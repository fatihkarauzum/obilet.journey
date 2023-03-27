namespace Obilet.Common.Services {
    public interface CookieService {

		string GetCookie(string key);

        void SetCookie(string key, string value, int? expirationDays = null);

        void SetCookie(List<KeyValuePair<string, string>> keyValuePairs, int? expirationDays = null);

        void RemoveCookie(string key);

	}
}
