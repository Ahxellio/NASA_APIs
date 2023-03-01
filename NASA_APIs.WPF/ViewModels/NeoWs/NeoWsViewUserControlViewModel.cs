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

namespace NASA_APIs.WPF.ViewModels.NeoWs
{
    public class NeoWsViewUserControlViewModel : BaseVM
    {
        public ObservableCollection<NASA_APIs.DAL.Entities.NearEarthObject> NeoWsValues { get; } = new();
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { Set(ref _Id, value); }
        }
        private NASA_APIs.DAL.Entities.NearEarthObject _SelectedItem;
        public NASA_APIs.DAL.Entities.NearEarthObject SelectedItem
        {
            get { return _SelectedItem; }
            set { Set(ref _SelectedItem, value);}
        }
        public ICommand NavigateMenuCommand { get; }
        public NeoWsViewUserControlViewModel(NavigationStore navigationStore, int id, 
            ObservableCollection<NASA_APIs.DAL.Entities.NearEarthObject> neowsvalues)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            if (id > 0)
                _Id = id;
            NeoWsValues = neowsvalues;
        }
    }
}
