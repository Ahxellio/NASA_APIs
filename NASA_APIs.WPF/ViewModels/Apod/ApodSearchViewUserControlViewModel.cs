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
    public class ApodSearchViewUserControlViewModel : BaseVM
    {
        //private static IHost _Hosting;

        //public static IHost Hosting => _Hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        //public static IServiceProvider Services => Hosting.Services;

        //public static IHostBuilder CreateHostBuilder(string[] args) => Host
        //   .CreateDefaultBuilder(args)
        //   .ConfigureServices(ConfigureServices);

        //private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        //{
        //    services.AddHttpClient<NASA_APIsClient>(client => client.BaseAddress = new Uri(host.Configuration["NASA"]));
        //}

        //private readonly IRepository<DataAPODValues> _DataSources;
        //public ObservableCollection<DataAPODValues> DataSources { get; } = new();


        //private LambdaCommand _AddDataSourceCommand;

        //public ICommand AddDataSourceCommand => _AddDataSourceCommand ??= new(OnAddDataSourceCommandExecuted);

        //private async void OnAddDataSourceCommandExecuted(object p)
        //{
        //    using var host = Hosting;
        //    await host.StartAsync();
        //    var apod = Services.GetRequiredService<NASA_APIsClient>();
        //    var pictures = await apod.GetAPOD(_Count);
        //    DataAPODValues model= new DataAPODValues();
        //    for(int i = 0; i < _Count; i++)
        //    {
        //        model.Text = pictures[i].Text;
        //        model.Title = pictures[i].Title;
        //        model.Name = pictures[i].Title;
        //        model.ImageUrl = pictures[i].ImageUrl;
        //        model.Date = pictures[i].Date;
        //        model.Source = "APOD";  
        //        model.Type = pictures[i].Type;
        //        await _DataSources.Add(model);
        //    }
        //}
        //private LambdaCommand _LoadDataSourceCommand;

        //public ICommand LoadDataSourceCommand => _LoadDataSourceCommand ??= new(OnLoadDataSourceCommandExecuted);

        //private async void OnLoadDataSourceCommandExecuted(object p)
        //{
        //    DataSources.Clear();
        //    foreach (var source in await _DataSources.GetAll())
        //        DataSources.Add(source);
        //}
        private int _Count;
        public int Count
        {
            get { return _Count; }
            set { Set(ref _Count, value); }
        }
        private string _Date;
        public string Date
        {
            get { return _Date; }
            set { Set(ref _Date, value); }
        }
        private string _StartPeriod;
        public string StartPeriod
        {
            get { return _StartPeriod; }
            set { Set(ref _StartPeriod, value); }
        }
        private string _EndPeriod;
        public string EndPeriod
        {
            get { return _EndPeriod; }
            set { Set(ref _EndPeriod, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodChoiceViewCommand { get; }
        public ApodSearchViewUserControlViewModel(NavigationStore navigationStore, int count, string date, string startPeriod, string endPeriod)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateApodChoiceViewCommand = new NavigateCommand<ApodSearchByCountChoiceUserControlViewModel>
               (new NavigationService<ApodSearchByCountChoiceUserControlViewModel>
               (navigationStore, () => new ApodSearchByCountChoiceUserControlViewModel(navigationStore)));
            if(count > 0 && date == null && startPeriod == null && endPeriod == null)
            {
                _Count = count;
            }
            else if (count <= 0 && date != null && startPeriod == null && endPeriod == null)
            {
                _Date = date;
            }
            else if (count <= 0 && date == null && startPeriod != null && endPeriod != null)
            {
                _StartPeriod = startPeriod;
                _EndPeriod = endPeriod;
            }
        }
    }
}
