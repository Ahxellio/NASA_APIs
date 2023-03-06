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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.Techport
{
    public class TechPortMenuUserControlViewModel : BaseVM
    {
        private static IHost _Hosting;

        public static IHost Hosting => _Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
           .CreateDefaultBuilder(args)
           .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<ClientRequests>(client => client.BaseAddress =
            new Uri(host.Configuration["NASA"]));
        }

        public ObservableCollection<Projects> TechPortValues { get; } = new();


        private LambdaCommand _AddDataSourceCommand;

        public ICommand AddDataSourceCommand => _AddDataSourceCommand ??= new(OnAddDataSourceCommandExecuted);
        private async void OnAddDataSourceCommandExecuted(object p)
        {
            TechPortValues.Clear();
            var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<ClientRequests>();
            var pictures = await apod.GetTechPort();
            var objects = pictures.Projects;
            foreach(var picture in objects)
            {
                TechPortValues.Add(picture);
            }

        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateTechPortDateCommand { get; }
        public ICommand NavigateTechPortIdCommand { get; }
        public ICommand NavigateTechPortAllProjectsCommand { get; }
        public TechPortMenuUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateTechPortDateCommand = new NavigateCommand<TechPortSearchByDateUserControlViewModel>
               (new NavigationService<TechPortSearchByDateUserControlViewModel>
               (navigationStore, () => new TechPortSearchByDateUserControlViewModel(navigationStore)));
            NavigateTechPortIdCommand = new NavigateCommand<TechPortSearchByIdUserControlViewModel>
               (new NavigationService<TechPortSearchByIdUserControlViewModel>
               (navigationStore, () => new TechPortSearchByIdUserControlViewModel(navigationStore)));
            NavigateTechPortAllProjectsCommand = new NavigateCommand<TechPortViewUserControlViewModel>
               (new NavigationService<TechPortViewUserControlViewModel>
               (navigationStore, () => new TechPortViewUserControlViewModel(navigationStore, null, -1, TechPortValues)));


        }
    }
}
