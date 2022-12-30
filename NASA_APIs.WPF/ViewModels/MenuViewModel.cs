
using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Apod;
using NASA_APIs.WPF.ViewModels.Base;
using NASA_APIs.WPF.ViewModels.Mars;
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
        public ICommand NavigateNeoWsControlCommand { get; }
        public ICommand NavigateTechPortControlCommand { get; }
        public ICommand NavigateTechPortProjectsControlCommand { get; }

        public ICommand NavigateTechTransferControlCommand { get; }

        public MenuViewModel(NavigationStore navigationStore)
        {
            NavigateApodControlCommand = new NavigateCommand<ApodMenuUserControlViewModel>
                (new NavigationService<ApodMenuUserControlViewModel>
                (navigationStore, () => new ApodMenuUserControlViewModel(navigationStore)));

            NavigateMarsControlCommand = new NavigateCommand<MarsMenuUserControlViewModel>
                (new NavigationService<MarsMenuUserControlViewModel>
                (navigationStore, () => new MarsMenuUserControlViewModel(navigationStore)));

            NavigateNeoWsControlCommand = new NavigateCommand<NeoWsMenuUserControlViewModel>
                (new NavigationService<NeoWsMenuUserControlViewModel>
                (navigationStore, () => new NeoWsMenuUserControlViewModel(navigationStore)));

            NavigateTechPortControlCommand = new NavigateCommand<TechPortMenuUserControlViewModel>
                (new NavigationService<TechPortMenuUserControlViewModel>
                (navigationStore, () => new TechPortMenuUserControlViewModel(navigationStore)));

            NavigateTechPortProjectsControlCommand = new NavigateCommand<TechPortProjectsMenuUserControlViewModel>
                (new NavigationService<TechPortProjectsMenuUserControlViewModel>
                (navigationStore, () => new TechPortProjectsMenuUserControlViewModel(navigationStore)));

            NavigateTechTransferControlCommand = new NavigateCommand<TechTransferMenuUserControlViewModel>
                (new NavigationService<TechTransferMenuUserControlViewModel>
                (navigationStore, () => new TechTransferMenuUserControlViewModel(navigationStore)));
        }
    }
}
