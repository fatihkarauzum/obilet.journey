using Microsoft.AspNetCore.Builder;
using Obilet.Core.Middlewares;

namespace Obilet.Core.Extensions {

    public static class MiddlewareRegistration
    {

        public static void AddMiddlewares(this IApplicationBuilder app)
        {

            app.UseMiddleware<RequestContext>();
            app.UseMiddleware<ErrorHandler>();

        }

    }

}
