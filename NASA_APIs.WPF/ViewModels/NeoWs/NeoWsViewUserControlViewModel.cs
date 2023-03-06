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
using System.Windows;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.NeoWs
{
    public class NeoWsViewUserControlViewModel : BaseVM
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

        private LambdaCommand _NextPageCommand;

        public ICommand NextPageCommand => _NextPageCommand ??= new(OnNextPageCommandExecuted);
        private async void OnNextPageCommandExecuted(object p)
        {
            NeoWsValues.Clear();
            if(_Page == 1601)
                _Page = 0;
            else
                _Page += 1;
            var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<ClientRequests>();
            var pictures = await apod.GetNeoWsPage(_Page);
            var objects = pictures.NearEarthObjects;
            foreach (var picture in objects)
            {
                NeoWsValues.Add(picture);
            }
        }
        private LambdaCommand _PreviousPageCommand;

        public ICommand PreviousPageCommand => _PreviousPageCommand ??= new(OnPreviousPageCommandExecuted);
        private async void OnPreviousPageCommandExecuted(object p)
        {
            NeoWsValues.Clear();
            if (_Page == 0)
                _Page = 1600;
            else
                _Page -= 1;
            var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<ClientRequests>();
            var pictures = await apod.GetNeoWsPage(_Page);
            var objects = pictures.NearEarthObjects;
            foreach (var picture in objects)
            {
                NeoWsValues.Add(picture);
            }
        }

        public ObservableCollection<NearEarthObject> NeoWsValues { get; } = new();

        private int _Page = 0;
        public int Page
        {
            get { return _Page; }
            set { Set(ref _Page, value); }
        }

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { Set(ref _Id, value); }
        }
        private NearEarthObject _SelectedItem;
        public NearEarthObject SelectedItem
        {
            get { return _SelectedItem; }
            set { Set(ref _SelectedItem, value);}
        }
        public ICommand NavigateMenuCommand { get; }
        public NeoWsViewUserControlViewModel(NavigationStore navigationStore, int id, 
            ObservableCollection<NASA_APIs.DAL.Entities.NearEarthObject> neowsvalues)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            if (id > 0)
                _Id = id;
            NeoWsValues = neowsvalues;
        }
    }
}
