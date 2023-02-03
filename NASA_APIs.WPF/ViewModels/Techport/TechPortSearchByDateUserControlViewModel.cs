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
    public class TechPortSearchByDateUserControlViewModel : BaseVM
    {
        private string _Date = DateTime.Now.ToShortDateString();
        public string Date
        {
            get { return _Date; }
            set { Set(ref _Date, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateTechPortViewCommand { get; }
        public TechPortSearchByDateUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateTechPortViewCommand = new NavigateCommand<TechPortViewUserControlViewModel>
                (new NavigationService<TechPortViewUserControlViewModel>
                (navigationStore, () => new TechPortViewUserControlViewModel(navigationStore,_Date, -1)));
        }
    }
}
