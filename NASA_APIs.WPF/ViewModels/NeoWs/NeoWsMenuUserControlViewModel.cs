using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NASA_APIs.DAL.Entities;
using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.NeoWs
{
    public class NeoWsMenuUserControlViewModel : BaseVM
    {
        private static IHost _Hosting;

        public static IHost Hosting => _Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
           .CreateDefaultBuilder(args)
           .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<ClientRequests>(client => client.BaseAddress = new Uri(host.Configuration["NASA"]));
        }

        public ObservableCollection<NASA_APIs.DAL.Entities.NearEarthObject> NeoWsValues { get; } = new();


        private LambdaCommand _AddDataSourceCommand;

        public ICommand AddDataSourceCommand => _AddDataSourceCommand ??= new(OnAddDataSourceCommandExecuted);
        private async void OnAddDataSourceCommandExecuted(object p)
        {
            NeoWsValues.Clear();
            using var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<ClientRequests>();
            var pictures = await apod.GetNeoWs();
            var objects = pictures.NearEarthObjects;
            foreach (var picture in objects)
            {
                NeoWsValues.Add(picture);
            }

        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateAllNeoWsCommand { get; }
        public ICommand NavigateByIdCommand { get; }
        public NeoWsMenuUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateAllNeoWsCommand = new NavigateCommand<NeoWsViewUserControlViewModel>
               (new NavigationService<NeoWsViewUserControlViewModel>
               (navigationStore, () => new NeoWsViewUserControlViewModel(navigationStore, -1, NeoWsValues)));
            NavigateByIdCommand = new NavigateCommand<NeoWsSearchByIdUserControlViewModel>
               (new NavigationService<NeoWsSearchByIdUserControlViewModel>
               (navigationStore, () => new NeoWsSearchByIdUserControlViewModel(navigationStore)));
        }
    }
}
