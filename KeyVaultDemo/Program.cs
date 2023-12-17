using B2C;
using B2C.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureHostConfiguration(configuration =>
    {
        configuration.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((services) =>
    {
        //var serviceProvider = services.BuildServiceProvider();
        //var config = serviceProvider.GetRequiredService<IConfiguration>();

        services.AddB2CConfigurationService();
    })
    .Build();

host.Run();