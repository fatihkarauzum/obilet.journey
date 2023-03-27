using Microsoft.AspNetCore.Http;
using MyCSharp.HttpUserAgentParser;
using Obilet.Common.Constants;
using Obilet.Common.Dtos;
using Obilet.Common.Utils;

namespace Obilet.Common.Services.Impl {
    public class RequestContextHolderImpl : RequestContextHolder {

        private readonly IHttpContextAccessor httpContextAccessor;

        public RequestContextHolderImpl(IHttpContextAccessor httpContextAccessor)
        {

            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetRealIp()
        {

            string realIp = "";

            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null)
            {
                object? realIpRef;
                httpContextAccessor.HttpContext.Items.TryGetValue(WebConstants.REAL_IP, out realIpRef);

                if (realIpRef != null)
                    realIp = (string)realIpRef;

            }

            if (realIp.Equals(WebConstants.LOCALHOST))
                realIp = await IpUtil.ResolveRealIp();

            return realIp;
        }

        public string GetRealPort()
        {

            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null)
                return httpContextAccessor.HttpContext.Connection.RemotePort.ToString();

            return "";
        }

        public HttpUserAgentInfo GetBrowserInfo()
        {
            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null)
            {
                string? userAgent = httpContextAccessor.HttpContext.GetUserAgentString();

                if (userAgent.IsNotNullOrEmpty())
                {
                    HttpUserAgentInformation parsedData = HttpUserAgentParser.Parse(userAgent);

                    return new HttpUserAgentInfo(parsedData.Name ?? "", parsedData.Version ?? "");
                }
            }

            return HttpUserAgentInfo.EMPTY;
        }
    }
}
