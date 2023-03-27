using Castle.DynamicProxy;
using Obilet.Business.Services;
using Obilet.Business.Services.Impl;
using Obilet.Common.Aspects;
using Obilet.Common.Services;
using Obilet.Common.Services.Impl;
using Obilet.Core.Attributes;

namespace Obilet.Core.Extensions {

	public static class ServiceRegistration {

		public static void AddInfrastructure(this IServiceCollection services) {

			services.AddSingleton<CacheService, CacheServiceImpl>();

			services.AddScoped<RequestContextHolder, RequestContextHolderImpl>();
			services.AddScoped<CookieService, CookieServiceImpl>();

			services.AddSingleton(new ProxyGenerator());
			services.AddScoped<IInterceptor, CacheableAspect>();


			services.AddScoped<SessionService, SessionServiceImpl>();
			services.AddProxiedScoped<BusLocationService, BusLocationServiceImpl>();
			services.AddScoped<JourneyService, JourneyServiceImpl>();
			
			services.AddScoped<SessionAttribute>();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		}

	}

}
