using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NASA_APIs.DAL.Entities;
using NASA_APIs.Interfaces.Base.Repositories;
using NASA_APIs.WebApiClients.Repositories;
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
            services.AddHttpClient<IRepository<ApodValue>, WebRepository<ApodValue>>(client =>
            {
                client.BaseAddress = new Uri($"{host.Configuration["WebAPI"]}/api/ApodValue/");
            });
        }
        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();

            var data_sources = Services.GetRequiredService<IRepository<ApodValue>>();
            var count = await data_sources.GetCount();
            Console.WriteLine($"Было элементов: {count}");



            var count2 = await data_sources.GetCount();
            Console.WriteLine($"Стало элементов: {count2}");

            Console.WriteLine();
            Console.WriteLine("Completed");
            Console.WriteLine();
            Console.ReadLine();
            await host.StopAsync();
        }
    }
}
