using Microsoft.Azure.Functions.Worker.Http;

namespace RCL.Core.Api.Authorization
{
    public interface IClientCredentialsAuthorizationService
    {
        bool IsAuthorized(HttpRequestData req);
    }
}
