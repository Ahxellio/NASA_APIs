using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MathCore.CommandProcessor;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using NASA_APIs.DAL.Entities;
using NASA_APIs.Interfaces.Base.Repositories;

namespace NASA_APIs.WPF.ViewModels
{
    public class MainWindowViewModel : TitledViewModel
    {
        private readonly IRepository<DataSource> _DataSources;

        public MainWindowViewModel(IRepository<DataSource> DataSources)
        {
            Title = "MainWindow";
            _DataSources = DataSources;
        }
        public ObservableCollection<DataSource> DataSources { get; } = new();


        private LambdaCommand _LoadDataSourceCommand;

        public ICommand LoadDataSourceCommand => _LoadDataSourceCommand ??= new(OnLoadDataSourceCommandExecuted);

        private async void OnLoadDataSourceCommandExecuted(object p)
        {
            DataSources.Clear();
            foreach (var source in await _DataSources.GetAll())
                DataSources.Add(source);
        }


    }
}
