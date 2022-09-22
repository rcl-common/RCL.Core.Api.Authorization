using Microsoft.Extensions.DependencyInjection.Extensions;
using RCL.Core.Api.Authorization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiAuthorizationExtension
    {
        public static IServiceCollection AddRCLCoreApiAuthorizationServices(this IServiceCollection services, Action<ApiAuthorizationOptions> setupAction)
        {
            services.TryAddTransient<IApiAuthorizationService, ApiAuthorizationService>();
            services.Configure(setupAction);

            return services;
        }
    }
}
