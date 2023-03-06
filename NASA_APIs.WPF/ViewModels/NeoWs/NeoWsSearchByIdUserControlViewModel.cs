using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NASA_APIs.DAL.Entities;
using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;
using NASA_APIs.WPF.ViewModels.Techport;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.NeoWs
{
    public class NeoWsSearchByIdUserControlViewModel : BaseVM
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { Set(ref _Id, value); }
        }
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

        public ObservableCollection<NearEarthObject> NeoWsValues { get; } = new();


        private LambdaCommand _AddDataSourceCommand;

        public ICommand AddDataSourceCommand => _AddDataSourceCommand ??= new(OnAddDataSourceCommandExecuted);
        private async void OnAddDataSourceCommandExecuted(object p)
        {
            NeoWsValues.Clear();
            var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<ClientRequests>();
            var pictures = await apod.GetNeoWs(_Id);
            var objects = pictures.NearEarthObjects;
            foreach (var picture in objects)
            {
                NeoWsValues.Add(picture);
            }

        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateNeoWsViewCommand { get; }
        public NeoWsSearchByIdUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateNeoWsViewCommand = new NavigateCommand<NeoWsViewUserControlViewModel>
                (new NavigationService<NeoWsViewUserControlViewModel>
                (navigationStore, () => new NeoWsViewUserControlViewModel(navigationStore, _Id, NeoWsValues)));
        }
    }
}
