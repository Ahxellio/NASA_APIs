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

namespace NASA_APIs.WPF.ViewModels.Apod
{
    public class ApodSearchForDayChoiceUserControlViewModel : BaseVM
    {
        private string _Date = DateTime.Now.ToShortDateString();
        public string Date
        {
            get { return _Date; }
            set { Set(ref _Date, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodViewCommand { get; }
        public ApodSearchForDayChoiceUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateApodViewCommand = new NavigateCommand<ApodSearchViewUserControlViewModel>
               (new NavigationService<ApodSearchViewUserControlViewModel>
               (navigationStore, () => new ApodSearchViewUserControlViewModel(navigationStore, -1, _Date, null, null)));
        }
    }
}
