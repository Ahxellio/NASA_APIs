using NASA_APIs.DAL.Entities;
using NASA_APIs.Interfaces.Base.Repositories;
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

namespace NASA_APIs.WPF.ViewModels
{
    public class ApodUserControlViewModel : BaseVM
    {
        public ObservableCollection<DataSource> DataSources { get; } = new();

        private readonly IRepository<DataSource> _DataSources;

        public ICommand LoadDataSourceCommand { get; }

        private bool CanLoadDataSourceCommandExecute(object p) => true;
        private async void OnLoadDataSourceCommandExecuted(object p)
        {
            DataSources.Clear();
            foreach (var source in await _DataSources.GetAll())
                DataSources.Add(source);
        }
        private readonly NavigationStore _navigationStore;
        public ICommand NavigateApodCommand { get; }
        public ApodUserControlViewModel()
        {
            //NavigateApodCommand = new NavigateCommand(navigationService);
            LoadDataSourceCommand = new LambdaCommand(OnLoadDataSourceCommandExecuted, CanLoadDataSourceCommandExecute);
        }
    }
}
