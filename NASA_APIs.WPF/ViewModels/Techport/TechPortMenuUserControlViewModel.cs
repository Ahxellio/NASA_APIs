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

namespace NASA_APIs.WPF.ViewModels.Techport
{
    public class TechPortMenuUserControlViewModel : BaseVM
    {
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateTechPortDateCommand { get; }
        public ICommand NavigateTechPortIdCommand { get; }
        public ICommand NavigateTechPortAllProjectsCommand { get; }
        public TechPortMenuUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateTechPortDateCommand = new NavigateCommand<TechPortSearchByDateUserControlViewModel>
               (new NavigationService<TechPortSearchByDateUserControlViewModel>
               (navigationStore, () => new TechPortSearchByDateUserControlViewModel(navigationStore)));
            NavigateTechPortIdCommand = new NavigateCommand<TechPortSearchByIdUserControlViewModel>
               (new NavigationService<TechPortSearchByIdUserControlViewModel>
               (navigationStore, () => new TechPortSearchByIdUserControlViewModel(navigationStore)));
            NavigateTechPortAllProjectsCommand = new NavigateCommand<TechPortViewUserControlViewModel>
               (new NavigationService<TechPortViewUserControlViewModel>
               (navigationStore, () => new TechPortViewUserControlViewModel(navigationStore, null, -1)));

        }
    }
}
