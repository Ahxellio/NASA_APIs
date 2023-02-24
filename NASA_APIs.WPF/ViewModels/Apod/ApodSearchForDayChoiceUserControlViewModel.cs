using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NASA_APIs.DAL.Entities;
using NASA_APIs.Interfaces.Base.Repositories;
using NASA_APIs.Models;
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

namespace NASA_APIs.WPF.ViewModels.Apod
{
    public class ApodSearchForDayChoiceUserControlViewModel : BaseVM
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

        public ObservableCollection<ApodValue> ApodValues { get; } = new();
        private LambdaCommand _AddDataSourceCommand;

        public ICommand AddDataSourceCommand => _AddDataSourceCommand ??= new(OnAddDataSourceCommandExecuted);
        private async void OnAddDataSourceCommandExecuted(object p)
        {
            using var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<ClientRequests>();
            var pictures = await apod.GetAPOD(_Date);
            foreach (var picture in pictures)
            {
                ApodValues.Add(picture);
            }

        }
        private string _Date = DateTime.Now.ToShortDateString();
        public string Date
        {
            get { return _Date; }
            set { Set(ref _Date, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodViewCommand { get; }
        public ApodSearchForDayChoiceUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateApodViewCommand = new NavigateCommand<ApodSearchViewUserControlViewModel>
               (new NavigationService<ApodSearchViewUserControlViewModel>
               (navigationStore, () => new ApodSearchViewUserControlViewModel(navigationStore, -1, _Date, null, 
               null, ApodValues)));
        }
    }
}
