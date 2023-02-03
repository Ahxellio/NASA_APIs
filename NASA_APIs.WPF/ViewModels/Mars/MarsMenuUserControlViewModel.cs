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
    public class MarsMenuUserControlViewModel : BaseVM
    {
        private int _Sol;
        public int Sol
        {
            get { return _Sol; }
            set { Set(ref _Sol, value); }
        }
        public ICommand NavigateMarsSolChoiceCommand { get; }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateMarsSolCameraCommand { get; }
        public ICommand NavigateMarsSolPageCommand { get; }
        public MarsMenuUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
                (new NavigationService<MenuViewModel>
                (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateMarsSolChoiceCommand = new NavigateCommand<MarsSearchForSolChoiceUserControlViewModel>
                (new NavigationService<MarsSearchForSolChoiceUserControlViewModel>
                (navigationStore, () => new MarsSearchForSolChoiceUserControlViewModel(navigationStore)));
            NavigateMarsSolCameraCommand = new NavigateCommand<MarsSearchForSolCameraUserControlViewModel>
                (new NavigationService<MarsSearchForSolCameraUserControlViewModel>
                (navigationStore, () => new MarsSearchForSolCameraUserControlViewModel(navigationStore)));
            NavigateMarsSolPageCommand = new NavigateCommand<MarsSearchForSolPageUserControlViewModel>
                (new NavigationService<MarsSearchForSolPageUserControlViewModel>
                (navigationStore, () => new MarsSearchForSolPageUserControlViewModel(navigationStore)));
        }
    }
}
