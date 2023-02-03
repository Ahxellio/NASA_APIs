using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;
using NASA_APIs.WPF.ViewModels.Techport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.NeoWs
{
    public class NeoWsSearchByIdUserControlViewModel : BaseVM
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { Set(ref _Id, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateNeoWsViewCommand { get; }
        public NeoWsSearchByIdUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateNeoWsViewCommand = new NavigateCommand<NeoWsViewUserControlViewModel>
                (new NavigationService<NeoWsViewUserControlViewModel>
                (navigationStore, () => new NeoWsViewUserControlViewModel(navigationStore, _Id)));
        }
    }
}
