using Transacoes.Interface;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Transacoes.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEY_HEADER_NAME = "X-API-KEY";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IApiKeyService apiKeyService)
        {
            var endpoint = context.GetEndpoint();
            var requiresAuth = endpoint?.Metadata?.GetMetadata<ApiKeyAuthAttribute>() != null;

            if (requiresAuth)
            {
                if (!context.Request.Headers.TryGetValue(APIKEY_HEADER_NAME, out var extractedApiKey))
                {
                    await ReturnUnauthorizedResponse(context, "API Key não fornecida.");
                    return;
                }

                var apiKey = await apiKeyService.GetByKeyAsync(extractedApiKey);

                if (apiKey == null)
                {
                    await ReturnUnauthorizedResponse(context, "API Key inválida.");
                    return;
                }
            }

            await _next(context);
        }

        private async Task ReturnUnauthorizedResponse(HttpContext context, string message)
        {
            context.Response.Clear();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json; charset=utf-8";

            var result = JsonSerializer.Serialize(
                new { message },
                new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                }
            );

            await context.Response.WriteAsync(result, System.Text.Encoding.UTF8);
        }
    }
}
