using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.Apod
{
    public class ApodSearchForPeriodChoiceUserControlViewModel : BaseVM
    {
        private string _StartPeriod = DateTime.MinValue.ToShortDateString();
        public string StartPeriod
        {
            get { return _StartPeriod; }
            set { Set(ref _StartPeriod, value); }
        }
        private string _EndPeriod = DateTime.MaxValue.ToShortDateString();
        public string EndPeriod
        {
            get { return _EndPeriod; }
            set { Set(ref _EndPeriod, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodViewCommand { get; }

        public ApodSearchForPeriodChoiceUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore))); 
            NavigateApodViewCommand = new NavigateCommand<ApodSearchViewUserControlViewModel>
               (new NavigationService<ApodSearchViewUserControlViewModel>
               (navigationStore, () => new ApodSearchViewUserControlViewModel(navigationStore, -1, null, _StartPeriod, EndPeriod)));
        }
    }
}
