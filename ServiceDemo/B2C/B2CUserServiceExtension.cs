using Azure.Identity;
using B2C.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using System.Text.Json;

namespace B2C
{
    public static class B2CUserServiceExtension
    {
        public static IServiceCollection AddB2CConfigurationService(this IServiceCollection service)
        {
            //Get Value from Environment
            var b2cConfig = JsonSerializer.Deserialize<B2CUserServiceConfiguration>(
                    Environment.GetEnvironmentVariable("AZUREADB2CSETTINGS_KV")
                );

            //Configure Service Using Values from Pervious Step
            service.Configure<B2CUserServiceConfiguration>(x =>
            {
                x.AppId = b2cConfig.AppId;
                x.TenantId = b2cConfig.TenantId;
                x.B2cExtensionAppClientId = b2cConfig.B2cExtensionAppClientId;
                x.Issuer = b2cConfig.Issuer;
                x.ClientSecret = b2cConfig.ClientSecret;
                x.Scopes = b2cConfig.Scopes;
                x.InitialPassword = b2cConfig.InitialPassword;
            });

            //Validations and Dependency Injection
            service.AddSingleton<IValidateOptions<B2CUserServiceConfiguration>, B2CUserServiceConfigurationValidation>();
            var b2cServiceConfiguration = service.BuildServiceProvider().GetRequiredService<IOptions<B2CUserServiceConfiguration>>().Value;
            service.AddSingleton<IB2CUserServiceConfiguration>(b2cServiceConfiguration);

            ClientSecretCredential authenticationProvider = new(
                    b2cServiceConfiguration.TenantId,
                    b2cServiceConfiguration.AppId,
                    b2cServiceConfiguration.ClientSecret
                );

            service.AddTransient(x => new GraphServiceClient(authenticationProvider, b2cServiceConfiguration.Scopes));
            service.AddTransient<IB2CUserService, B2CUserService>();

            return service;
        }
    }
}
