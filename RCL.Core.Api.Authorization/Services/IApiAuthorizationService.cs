using Microsoft.Azure.Functions.Worker.Http;

namespace RCL.Core.Api.Authorization
{
    public interface IApiAuthorizationService
    {
        bool IsClientAuthorized(HttpRequestData req);
        bool IsSecurityKeyAuthorized(HttpRequestData req, string keyName);
    }
}
