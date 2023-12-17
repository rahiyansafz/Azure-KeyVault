namespace B2C.Configurations
{
    public interface IB2CUserServiceConfiguration
    {
        string TenantId { get; set; }
        string AppId { get; set; }
        string Issuer { get; set; }
        string ClientSecret { get; set; }
        string B2cExtensionAppClientId { get; set; }
        public string[] Scopes { get; set; }
    }
}
