namespace Samples.MT.Common.Api;

public static class Constants
{
    public static class ConfigurationSectionNames
    {
        public const string Auth0Identity = "Auth0Identity";
        public const string PlatformDb = "Db:PlatformDb";
        public const string TenantDb = "Db:TenantDb";
        public const string RedisCache = "RedisCache";
    }

    public static class Claims
    {
        public const string PermissionsClaimName = "permissions";
        public const string UserEmailClaimName = "user_email";
        public const string OrganizationIdClaimName = "org_id";
        public const string TenantIdClaimName = "tenant_id";
        public const string PortalUserIdClaimName = "portal_user_id";
    }
}