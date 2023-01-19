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

namespace NASA_APIs.WPF.ViewModels.Mars
{
    public class MarsSearchForSolCameraUserControlViewModel : BaseVM
    {
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateMarsViewCommand { get; }
        public MarsSearchForSolCameraUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateMarsViewCommand = new NavigateCommand<MarsSearchViewUserControlViewModel>
               (new NavigationService<MarsSearchViewUserControlViewModel>
               (navigationStore, () => new MarsSearchViewUserControlViewModel(navigationStore)));
        }
    }
}
