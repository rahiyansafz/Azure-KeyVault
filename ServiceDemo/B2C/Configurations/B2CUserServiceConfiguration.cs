namespace B2C.Configurations
{
    public class B2CUserServiceConfiguration : IB2CUserServiceConfiguration
    {
        public const string B2CUserServiceSettings = "AZUREADB2CSETTINGS_KV";
        public string TenantId { get; set; }
        public string Issuer { get; set; }

        public string AppId { get; set; }
        public string ClientSecret { get; set; }
        public string B2cExtensionAppClientId { get; set; }
        public string InitialPassword { get; set; }
        public string[] Scopes { get; set; }
    }
}
