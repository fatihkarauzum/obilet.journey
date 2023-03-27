using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Obilet.Common.Utils;
using System.Text;
using System.Web;

namespace Obilet.Common.Services.Impl {
	public class CookieServiceImpl : CookieService {

		private readonly IHttpContextAccessor httpContextAccessor;

		public CookieServiceImpl(IHttpContextAccessor httpContextAccessor) {
			this.httpContextAccessor = httpContextAccessor;
		}

		public string GetCookie(string key) {      
			if (httpContextAccessor.HttpContext == null || httpContextAccessor.HttpContext.Request == null)
				return "";

			string cookie = httpContextAccessor.HttpContext.Request.Cookies[key];

			if (StringUtil.IsNullOrEmpty(cookie))
				cookie = GetCookieValueFromResponse(httpContextAccessor.HttpContext.Response, key);

			return cookie;
		}

		public void SetCookie(string key, string value, int? expirationDays = null) {
			if (httpContextAccessor.HttpContext == null || httpContextAccessor.HttpContext.Response == null)
				return;

			CookieOptions options = new CookieOptions();
			if (expirationDays.HasValue)
				options.Expires = DateTime.Now.AddDays(expirationDays.Value);

			httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
		}

        public void SetCookie(List<KeyValuePair<string, string>> keyValuePairs, int? expirationDays = null) {
            if (httpContextAccessor.HttpContext == null || httpContextAccessor.HttpContext.Response == null)
                return;

            CookieOptions options = new CookieOptions();
            if (expirationDays.HasValue)
                options.Expires = DateTime.Now.AddDays(expirationDays.Value);

            foreach (KeyValuePair<string, string> kvp in keyValuePairs) {
                httpContextAccessor.HttpContext.Response.Cookies.Append(kvp.Key, kvp.Value, options);
            }
        }

        public void RemoveCookie(string key) {
			if (httpContextAccessor.HttpContext == null || httpContextAccessor.HttpContext.Response == null)
				return;

			httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
		}

		private string GetCookieValueFromResponse(HttpResponse response, string cookieName) {
			if (!response.Headers.TryGetValue("Set-Cookie", out StringValues cookieHeaders))
				return "";

			string cookieHeader = cookieHeaders.FirstOrDefault(header => header.StartsWith($"{cookieName}="));

			if (cookieHeader == null) 
				return "";

			int start = cookieHeader.IndexOf('=') + 1;
			int end = cookieHeader.IndexOf(';', start);

			string cookie = cookieHeader.Substring(start, end - start);
			return Uri.UnescapeDataString(cookie);
		}

	}
}
