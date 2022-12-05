using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NASA_APIs.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NASA_APIs.TestConsole
{
    class Program
    {

        private static IHost _Hosting;

        public static IHost Hosting => _Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
           .CreateDefaultBuilder(args)
           .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<NASA_APIsClient>(client => client.BaseAddress = new Uri(host.Configuration["NASA"]));
        }
        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<NASA_APIsClient>();
            var picture = await apod.GetTechPort(2020);
            Console.WriteLine("END!!!");
            Console.ReadLine();
            await host.StopAsync();
            //54051288
        }
    }
}
