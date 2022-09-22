using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Options;

namespace RCL.Core.Api.Authorization
{
    internal class ClientCredentialsAuthorizationService : IClientCredentialsAuthorizationService
    {
        private readonly IOptions<ApiAuthorizationOptions> _options;

        public ClientCredentialsAuthorizationService(IOptions<ApiAuthorizationOptions> options)
        {
            _options = options;
        }

        public bool IsAuthorized(HttpRequestData req)
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
    }
}
