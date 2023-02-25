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

namespace NASA_APIs.WPF.ViewModels.Mars
{
    public class MarsSearchForSolChoiceUserControlViewModel : BaseVM
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
        public ObservableCollection<DAL.Entities.Photo> PhotosValues { get; set; } = new();


        private LambdaCommand _AddDataSourceCommand;

        public ICommand AddDataSourceCommand => _AddDataSourceCommand ??= new(OnAddDataSourceCommandExecuted);
        private async void OnAddDataSourceCommandExecuted(object p)
        {
            PhotosValues.Clear();
            using var host = Hosting;
            await host.StartAsync();
            var apod = Services.GetRequiredService<ClientRequests>();
            MarsValue pictures = await apod.GetMarsPhotos(_Sol);
            List<DAL.Entities.Photo> rovers = pictures.Photos;
            foreach (var photo in rovers)
            {
                PhotosValues.Add(photo);
            }

        }
        private int _Sol;
        public int Sol
        {
            get { return _Sol; }
            set { Set(ref _Sol, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateMarsViewCommand { get; }
        public MarsSearchForSolChoiceUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
                (new NavigationService<MenuViewModel>
                (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateMarsViewCommand = new NavigateCommand<MarsSearchViewUserControlViewModel>
               (new NavigationService<MarsSearchViewUserControlViewModel>
               (navigationStore, () => new MarsSearchViewUserControlViewModel(navigationStore, _Sol, 0, null, PhotosValues)));

        }
    }
}
