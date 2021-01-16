using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;
namespace World.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Run();
        }

        public static IWebHost CreateHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build())
            .UseStartup<Startup>()
            .ConfigureServices(services => services.AddAutofac())
            .Build();
    }
}
