using System;
using System.Threading.Tasks;
using Commons.Api.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Commons.Api.Middleware
{
    public class SwaggerAuthentication
    {
        const string SwaggerUrl = "/swagger";
        readonly RequestDelegate _next;
        readonly ILogger _logger;

        public SwaggerAuthentication(RequestDelegate next, ILogger<SwaggerAuthentication> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            if (IsSwaggerRequest(context.Request) && !context.User.Identity.IsAuthenticated)
            {
                _logger.LogWarning($"The swagger request is not authenticated!");
                throw new SecurityException("Request is not authenticated!");
            }
            else
            {
                await _next(context);
            }
        }

        static bool IsSwaggerRequest(HttpRequest request)
        {
            return request.Path.Value.StartsWith(SwaggerUrl);
        }
    }

    public static class SwaggerAuthenticationMiddlewareExtension
    {
        public static IApplicationBuilder UseSwaggerAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SwaggerAuthentication>();
        }
    }
}
