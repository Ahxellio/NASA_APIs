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
using System.Windows;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.Apod
{
    public class ApodSearchForPeriodChoiceUserControlViewModel : BaseVM
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

        private readonly IRepository<DataAPODValues> _DataSources;
        public ObservableCollection<APODModel> DataSources { get; } = new();


        private LambdaCommand _AddDataSourceCommand;

        public ICommand AddDataSourceCommand => _AddDataSourceCommand ??= new(OnAddDataSourceCommandExecuted);
        private async void OnAddDataSourceCommandExecuted(object p)
        {
            DataSources.Clear();
            using var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<NASA_APIsClient>();
            var pictures = await apod.GetAPOD(_StartPeriod, _EndPeriod);
            APODModel model = new APODModel();
            foreach (var picture in pictures)
            {
                DataSources.Add(picture);
            }

        }
        private string _StartPeriod = DateTime.MinValue.ToShortDateString();
        public string StartPeriod
        {
            get { return _StartPeriod; }
            set { Set(ref _StartPeriod, value); }
        }
        private string _EndPeriod = DateTime.MaxValue.ToShortDateString();
        public string EndPeriod
        {
            get { return _EndPeriod; }
            set { Set(ref _EndPeriod, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodViewCommand { get; }

        public ApodSearchForPeriodChoiceUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore))); 
            NavigateApodViewCommand = new NavigateCommand<ApodSearchViewUserControlViewModel>
               (new NavigationService<ApodSearchViewUserControlViewModel>
               (navigationStore, () => new ApodSearchViewUserControlViewModel(navigationStore, -1, null, 
               _StartPeriod, EndPeriod, DataSources)));
        }
    }
}
