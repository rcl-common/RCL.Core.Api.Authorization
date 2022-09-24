namespace RCL.Core.Api.Authorization.Abstractions
{
    public interface IAuthorizationFactory
    {
        IApiAuthorization Create(AuthType authType);
    }
}
