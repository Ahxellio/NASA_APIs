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
    public class MarsSearchForSolChoiceUserControlViewModel : BaseVM
    {
        private int _Sol;
        public int Sol
        {
            get { return _Sol; }
            set { Set(ref _Sol, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateMarsViewCommand { get; }
        public MarsSearchForSolChoiceUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
                (new NavigationService<MenuViewModel>
                (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateMarsViewCommand = new NavigateCommand<MarsSearchViewUserControlViewModel>
               (new NavigationService<MarsSearchViewUserControlViewModel>
               (navigationStore, () => new MarsSearchViewUserControlViewModel(navigationStore, _Sol, 0, null)));

        }
    }
}
