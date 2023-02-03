using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;
using NASA_APIs.WPF.Views.UserControls.TechTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.TechTransfer
{
    public class TechTransferMenuUserControlViewModel : BaseVM
    {
        private string _Soft;
        public string Soft
        {
            get { return _Soft; }
            set { Set(ref _Soft, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateTechTransferViewCommand { get; }
        public TechTransferMenuUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateTechTransferViewCommand = new NavigateCommand<TechTransferViewUserControlViewModel>
               (new NavigationService<TechTransferViewUserControlViewModel>
               (navigationStore, () => new TechTransferViewUserControlViewModel(navigationStore)));
        }
    }
}
