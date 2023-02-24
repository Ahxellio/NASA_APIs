using NASA_APIs.DAL.Entities;
using NASA_APIs.Interfaces.Base.Repositories;
using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.Apod
{
    public class ApodMenuUserControlViewModel : BaseVM
    {
        public ICommand NavigateApodCountChoiceCommand { get; }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodPeriodChoiceCommand { get; }
        public ICommand NavigateApodDayChoiceCommand { get; }
        public ApodMenuUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateApodCountChoiceCommand = new NavigateCommand<ApodSearchByCountChoiceUserControlViewModel>
               (new NavigationService<ApodSearchByCountChoiceUserControlViewModel>
               (navigationStore, () => new ApodSearchByCountChoiceUserControlViewModel(navigationStore)));
            NavigateApodPeriodChoiceCommand = new NavigateCommand<ApodSearchForPeriodChoiceUserControlViewModel>
               (new NavigationService<ApodSearchForPeriodChoiceUserControlViewModel>
               (navigationStore, () => new ApodSearchForPeriodChoiceUserControlViewModel(navigationStore)));
            NavigateApodDayChoiceCommand = new NavigateCommand<ApodSearchForDayChoiceUserControlViewModel>
               (new NavigationService<ApodSearchForDayChoiceUserControlViewModel>
               (navigationStore, () => new ApodSearchForDayChoiceUserControlViewModel(navigationStore)));

        }
    }
}
