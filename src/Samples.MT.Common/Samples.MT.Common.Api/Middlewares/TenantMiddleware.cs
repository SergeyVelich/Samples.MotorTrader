using Microsoft.AspNetCore.Http;
using Samples.Infrastructure.Api.Middlewares;
using Samples.Infrastructure.Common.Abstractions;
using Samples.MT.Common.Services.Abstractions;
using Samples.MT.Common.Services.Multitenancy.Abstractions;
using System.Security.Claims;
using static Samples.MT.Common.Api.Constants;

namespace Samples.MT.Common.Api.Middlewares;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, ITenantConfigurationProvider tenantConfigurationProvider, IRequestContext requestContext, IDbOperationContext dbOperationContext)
    {
        var user = httpContext.User;
        var organizationIdClaim = user.Claims.FirstOrDefault(c => c.Type == Claims.OrganizationIdClaimName);
        if (organizationIdClaim is null)
        {
            await MiddlewareHelpers.WriteErrorToResponse(httpContext.Response, "Organization id is missing.");
            return;
        }

        var tenantId = await GetTenantId(organizationIdClaim.Value, tenantConfigurationProvider);
        if (!tenantId.HasValue)
        {
            await MiddlewareHelpers.WriteErrorToResponse(httpContext.Response, $"Tenant for {organizationIdClaim.Value} is missing.");
            return;
        }

        SetRequestContext(requestContext, httpContext, user, tenantId.Value);
        SetDbOperationContext(dbOperationContext, user);//TODO Refactor to use requestContext?

        await _next.Invoke(httpContext);
    }

    private static async Task<int?> GetTenantId(string organizationId, ITenantConfigurationProvider tenantConfigurationProvider)
    {
        var tenants = await tenantConfigurationProvider.GetTenantConfigurationsAsync(default);
        return tenants
            .FirstOrDefault(t => t.ExternalId == organizationId)
            ?.Id;
    }

    private void SetRequestContext(IRequestContext requestContext, HttpContext httpContext, ClaimsPrincipal user, int tenantId)
    {
        requestContext.UserId = GetUserId(user);
        requestContext.UserExternalId = user.Identity?.Name;
        requestContext.TenantId = tenantId;
        requestContext.TargetTenantId = GetTenantIdFromQuery(httpContext) ?? tenantId;
        requestContext.TenantExternalId = user.Claims.FirstOrDefault(claim => claim.Type == Claims.OrganizationIdClaimName)?.Value;
    }

    private void SetDbOperationContext(IDbOperationContext dbOperationContext, ClaimsPrincipal user)
    {
        dbOperationContext.UserId = GetUserId(user);
    }

    private Guid? GetUserId(ClaimsPrincipal user)
    {
        var claimUserId = user.Claims.FirstOrDefault(claim => claim.Type == Claims.PortalUserIdClaimName)?.Value;
        if (Guid.TryParse(claimUserId, out var userId))
        {
            return userId;
        }

        return null;
    }

    private int? GetTenantIdFromQuery(HttpContext httpContext)
    {
        var stringTenantId = httpContext?.Request.RouteValues["tenantId"]?.ToString();
        if (int.TryParse(stringTenantId, out var tenantId))
        {
            return tenantId;
        }

        return null;
    }
}