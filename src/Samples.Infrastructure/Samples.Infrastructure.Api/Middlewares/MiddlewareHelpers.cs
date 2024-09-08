using Microsoft.AspNetCore.Http;
using System.Net;

namespace Samples.Infrastructure.Api.Middlewares;

public static class MiddlewareHelpers
{
    public static async Task WriteErrorToResponse(HttpResponse response, string errorMessage)
    {
        response.StatusCode = (int)HttpStatusCode.BadRequest;
        response.ContentType = "text/plain";
        await response.WriteAsync(errorMessage);
    }

    public static async Task WriteForbiddenResponse(HttpResponse response, string errorMessage)
    {
        response.StatusCode = (int)HttpStatusCode.Forbidden;
        response.ContentType = "text/plain";
        await response.WriteAsync(errorMessage);
    }
}