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

namespace NASA_APIs.WPF.ViewModels.Techport
{
    public class TechPortViewForIdUserControlViewModel : BaseVM
    {
        public ObservableCollection<TechPortValue> TechPortValues { get; } = new();
        public ICommand NavigateMenuCommand { get; }
        public TechPortViewForIdUserControlViewModel(NavigationStore navigationStore, 
            ObservableCollection<TechPortValue> techportValues)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            TechPortValues = techportValues;
        }
    }
}
