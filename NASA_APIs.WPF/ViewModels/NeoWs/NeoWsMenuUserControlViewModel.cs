using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.NeoWs
{
    public class NeoWsMenuUserControlViewModel : BaseVM
    {
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateAllNeoWsCommand { get; }
        public ICommand NavigateByIdCommand { get; }
        public NeoWsMenuUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateAllNeoWsCommand = new NavigateCommand<NeoWsViewUserControlViewModel>
               (new NavigationService<NeoWsViewUserControlViewModel>
               (navigationStore, () => new NeoWsViewUserControlViewModel(navigationStore, -1)));
            NavigateByIdCommand = new NavigateCommand<NeoWsSearchByIdUserControlViewModel>
               (new NavigationService<NeoWsSearchByIdUserControlViewModel>
               (navigationStore, () => new NeoWsSearchByIdUserControlViewModel(navigationStore)));
        }
    }
}
