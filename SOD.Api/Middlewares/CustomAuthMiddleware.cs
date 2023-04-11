using Deneme.Authorization.Nuget.Business.Utilities.AppSettings;
using Deneme.Authorization.Nuget.Business.Utilities.AuthorizeHelpers;
using Deneme.Authorization.Nuget.Business.Utilities.Session;
using Deneme.Authorization.Nuget.Constant;
using Deneme.Authorization.Nuget.Exceptions;
using Deneme.Authorization.Nuget.Model.Authorize;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SOD.Core;
using System.Net;

namespace SOD.Api.Middlewares
{
    public class CustomAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<Settings> _sampleSettings;

        public CustomAuthMiddleware(RequestDelegate next, IOptions<Settings> portalSettings)
        {
            _next = next;
            _sampleSettings = portalSettings;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var endpoint = httpContext.GetEndpoint();

            if (endpoint is not null)
            {
                var hasPerm = endpoint.Metadata.OfType<HasPermissionAttribute>().ToList();

                if (hasPerm is not null && hasPerm.Count != 0)
                {
                    var token = httpContext.Request.Headers["Authorization"].ToString();

                    if (token.IsNullOrEmpty())
                        throw new CustomException(TokenConstant.NOT_FOUND_TOKEN, HttpStatusCode.Unauthorized);

                    try
                    {
                        var tokenHelper = new TokenHelper(_sampleSettings);
                        var loginUser = tokenHelper.ValidateToken(token);

                        if (loginUser is null)
                            throw new CustomException(TokenConstant.INVALID_TOKEN, HttpStatusCode.Unauthorized);

                        new SessionManager(httpContext)
                        {
                            User = new UserSessionModel
                            {
                                Username = loginUser.Username,
                                PersonnelId = loginUser.PersonnelId,
                                Roles = loginUser.Roles
                            }
                        };

                    }
                    catch (CustomException customException)
                    {
                        throw customException;
                    }
                    catch (Exception)
                    {
                        throw new CustomException(TokenConstant.NOT_FOUND_TOKEN, HttpStatusCode.Unauthorized);
                    }
                }

            }

            await _next(httpContext);
        }
    }
    public static class CustomAuthMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthMiddleware>();
        }
    }
}
