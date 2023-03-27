using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Obilet.Core.Middlewares.Exceptions;
using System.Text.Json;

namespace Obilet.Core.Middlewares {
    public class ErrorHandler {

        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandler> logger;

        public ErrorHandler(RequestDelegate next, ILogger<ErrorHandler> logger) {

            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context) {

            try {
                await next(context);
            }
            catch (Exception error) {
                context.Response.ContentType = "application/json";
                string result;

                switch (error) {
                    case JourjeyException e:
                        result = JsonSerializer.Serialize(new { e?.Error, error_description = e?.Ex?.Message, ex = "JourjeyException" });
                        logger.LogError(message: e?.Error, exception: e?.Ex);
                        break;
                    default:
                        result = JsonSerializer.Serialize(new { error = error?.Message, error_description = error?.InnerException });
                        logger.LogError(message: "Error", exception: error);
                        break;
                }

                await context.Response.WriteAsync(result);
            }
        }
    }
}
