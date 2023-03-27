using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Obilet.Common.Constants;

namespace Obilet.Core.Middlewares {

    public class RequestContext {

        private readonly RequestDelegate next;
        private readonly ILogger<RequestContext> logger;

        public RequestContext(RequestDelegate next, ILogger<RequestContext> logger) {

            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext) {

            try {
                string remoteIpAddress = httpContext.Connection.RemoteIpAddress.ToString();

                httpContext.Items[WebConstants.REAL_IP] = remoteIpAddress;
                await next(httpContext);
            }
            catch (Exception ex) {
                logger.LogError($"Request context error : {ex.Message}");
            }
        }

    }

}
