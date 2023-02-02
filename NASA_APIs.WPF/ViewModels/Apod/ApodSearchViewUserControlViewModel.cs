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
    public class ApodSearchViewUserControlViewModel : BaseVM
    {
        private int _Count;
        public int Count
        {
            get { return _Count; }
            set { Set(ref _Count, value); }
        }
        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { Set(ref _Date, value); }
        }
        private DateTime _StartPeriod;
        public DateTime StartPeriod
        {
            get { return _StartPeriod; }
            set { Set(ref _StartPeriod, value); }
        }
        private DateTime _EndPeriod;
        public DateTime EndPeriod
        {
            get { return _EndPeriod; }
            set { Set(ref _EndPeriod, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodChoiceViewCommand { get; }
        public ApodSearchViewUserControlViewModel(NavigationStore navigationStore, int count = default, DateTime date = default, DateTime startPeriod = default, DateTime endPeriod = default)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateApodChoiceViewCommand = new NavigateCommand<ApodSearchByCountChoiceUserControlViewModel>
               (new NavigationService<ApodSearchByCountChoiceUserControlViewModel>
               (navigationStore, () => new ApodSearchByCountChoiceUserControlViewModel(navigationStore)));
            _Count = count;
            _Date = date;
            _StartPeriod = startPeriod;
            _EndPeriod = endPeriod;
        }
    }
}
