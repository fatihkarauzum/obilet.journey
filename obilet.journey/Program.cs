using Microsoft.AspNetCore.HttpOverrides;
using Obilet.Core.Extensions;
using Obilet.Common.Clients.Obilet;
using Obilet.Model.Models.Configurations;
using System.Net.Http.Headers;
using Serilog;
using Serilog.Sinks.Graylog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
ConfigurationManager configuration = builder.Configuration;

var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Graylog(new GraylogSinkOptions {
                HostnameOrAddress = configuration.GetValue<string>("Logging:Graylog:Address"),
                Port = configuration.GetValue<int>("Logging:Graylog:Port"),
                TransportType = Serilog.Sinks.Graylog.Core.Transport.TransportType.Udp
            })
            .CreateLogger();

builder.Logging.AddSerilog(logger);

services.AddControllersWithViews();

services.Configure<ObiletHttpClientConfig>(configuration.GetSection("ObiletHttpClientConfig"));
services.Configure<ForwardedHeadersOptions>(options => {
	options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
	options.ForwardLimit = null;
	options.KnownProxies.Clear();
});

ObiletHttpClientConfig obiletHttpClientConfig = configuration.GetSection("ObiletHttpClientConfig").Get<ObiletHttpClientConfig>();
services.AddHttpClient<ObiletClient>(
	client => {
		client.BaseAddress = new Uri(obiletHttpClientConfig.ApiEndPoint);

		client.Timeout = new TimeSpan(0, 0, 30);

		MediaTypeWithQualityHeaderValue acceptMt = new MediaTypeWithQualityHeaderValue(obiletHttpClientConfig.Accept);
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(acceptMt);

		client.DefaultRequestHeaders.Authorization =
			new AuthenticationHeaderValue(
				obiletHttpClientConfig.Authorization.Scheme, 
				obiletHttpClientConfig.Authorization.ApiClientToken
			); // TODO: Setup Secret Manager
	}
);

services.AddInfrastructure();

services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseForwardedHeaders();

app.UseRouting();

app.UseAuthorization();

app.AddMiddlewares();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
