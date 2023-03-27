using Obilet.Common.Dtos;

namespace Obilet.Common.Services {

	public interface RequestContextHolder {

        Task<string> GetRealIp();

		string GetRealPort();

		HttpUserAgentInfo GetBrowserInfo();

	}

}
