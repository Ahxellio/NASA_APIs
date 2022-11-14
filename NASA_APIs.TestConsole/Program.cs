using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddHttpClient<NASA_APIsClient>(client => client.BaseAddress = new Uri(host.Configuration["APOD"]));
        }
        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<NASA_APIsClient>();
            var picture = await apod.GetAPOD(1);
            Console.WriteLine("END!!!");
            Console.ReadLine();
            await host.StopAsync();
        }
    }
}
