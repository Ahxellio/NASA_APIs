
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

namespace NASA_APIs.WPF.ViewModels
{
    public class MenuViewModel : BaseVM
    {
        public ICommand NavigateMarsControlCommand { get; }
        public ICommand NavigateApodControlCommand { get; }
        public MenuViewModel(NavigationStore navigationStore)
        {
            NavigateApodControlCommand = new NavigateCommand<ApodMenuUserControlViewModel>
                (new NavigationService<ApodMenuUserControlViewModel>
                (navigationStore, () => new ApodMenuUserControlViewModel(navigationStore)));

            NavigateMarsControlCommand = new NavigateCommand<MarsMenuUserControlViewModel>
                (new NavigationService<MarsMenuUserControlViewModel>
                (navigationStore, () => new MarsMenuUserControlViewModel(navigationStore)));
        }
    }
}
