using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NASA_APIs.DAL.Entities;
using NASA_APIs.Interfaces.Base.Repositories;
using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;

namespace NASA_APIs.WPF.ViewModels
{
    public class MainWindowViewModel : BaseVM
    {
        private readonly NavigationStore _navigationStore;

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public BaseVM CurrentViewModel => _navigationStore.CurrentViewModel;



    }
}
