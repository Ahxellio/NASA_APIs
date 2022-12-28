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
    public class ApodSearchByCountChoiceUserControlViewModel : BaseVM
    {
        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { Set(ref _Text, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodMenuCommand { get; }
        public ICommand NavigateApodViewCommand { get; }
        public ApodSearchByCountChoiceUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateApodMenuCommand = new NavigateCommand<ApodMenuUserControlViewModel>
               (new NavigationService<ApodMenuUserControlViewModel>
               (navigationStore, () => new ApodMenuUserControlViewModel(navigationStore)));
            NavigateApodViewCommand = new NavigateCommand<ApodSerachByCountViewUserControlViewModel>
               (new NavigationService<ApodSerachByCountViewUserControlViewModel>
               (navigationStore, () => new ApodSerachByCountViewUserControlViewModel(navigationStore)));

        }
    }
}
