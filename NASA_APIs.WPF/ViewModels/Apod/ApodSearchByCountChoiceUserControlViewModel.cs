using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NASA_APIs.DAL.Entities;
using NASA_APIs.DAL.Repositories;
using NASA_APIs.Interfaces.Base.Repositories;
using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;
using NASA_APIs.WPF.Views.UserControls.Apod;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.Apod
{
    public class ApodSearchByCountChoiceUserControlViewModel : BaseVM
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
            ApodValues.Clear();
            var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<ClientRequests>();
            var pictures = await apod.GetAPOD(_Count);
            foreach(var picture in pictures)
            { 
                ApodValues.Add(picture);
            }

        }
        private int _Count;
        public int Count
        {
            get { return _Count; }
            set { Set(ref _Count, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodMenuCommand { get; }
        public ICommand NavigateApodViewCommand { get; }
        public ApodSearchByCountChoiceUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateApodMenuCommand = new NavigateCommand<ApodMenuUserControlViewModel>
               (new NavigationService<ApodMenuUserControlViewModel>
               (navigationStore, () => new ApodMenuUserControlViewModel(navigationStore)));
            NavigateApodViewCommand = new NavigateCommand<ApodSearchViewUserControlViewModel>
               (new NavigationService<ApodSearchViewUserControlViewModel>
               (navigationStore, () => new ApodSearchViewUserControlViewModel(navigationStore, Count, 
               null, null, null, ApodValues)));

        }
    }
}
