using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Options;

namespace RCL.Core.Api.Authorization
{
    internal class ApiAuthorizationService : IApiAuthorizationService
    {
        private readonly IOptions<ApiAuthorizationOptions> _options;

        public ApiAuthorizationService(IOptions<ApiAuthorizationOptions> options)
        {
            _options = options;
        }

        public bool IsClientAuthorized(HttpRequestData req)
        {
            bool b = false;

            string accesstoken = AuthTokenHelper.GetAccessToken(req);

            if (!string.IsNullOrEmpty(accesstoken))
            {
                string clientId = AuthTokenHelper.GetClientId(accesstoken);

                if (!string.IsNullOrEmpty(clientId))
                {
                    List<string> clientIds = _options.Value.clientIds.Split(',').ToList();

                    if (clientIds?.Count > 0)
                    {
                        if (clientIds.Contains(clientId))
                        {
                            b = true;
                        }
                    }
                }
            }

            return b;
        }

        public bool IsSecurityKeyAuthorized(HttpRequestData req, string keyName)
        {
            bool b = false;

            var headers = req.Headers;
            string securityKey = string.Empty;
            if (headers.TryGetValues(keyName, out var keys))
            {
                securityKey = keys?.FirstOrDefault() ?? string.Empty;
            }

            if(securityKey == _options?.Value?.securityKey)
            {
                b = true;
            }

            return b;
        }
    }
}
