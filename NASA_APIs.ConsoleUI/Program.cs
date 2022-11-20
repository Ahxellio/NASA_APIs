using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace NASA_APIs.ConsoleUI
{
    internal class Program
    {
        private static IHost _Hosting;

        public static IHost Hosting => _Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
           .CreateDefaultBuilder(args)
           .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            
        }
        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();
            Console.WriteLine();
            Console.WriteLine("Completed");
            Console.WriteLine();
            await host.StopAsync();
        }
    }
}
