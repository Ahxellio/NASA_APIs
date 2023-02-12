using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NASA_APIs.DAL.Entities;
using NASA_APIs.Interfaces.Base.Repositories;
using NASA_APIs.Models;
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
    public class ApodSearchViewUserControlViewModel : BaseVM
    {
        public ObservableCollection<APODModel> DataSources { get; } = new();

        private int _Count;
        public int Count
        {
            get { return _Count; }
            set { Set(ref _Count, value); }
        }
        private string _Date;
        public string Date
        {
            get { return _Date; }
            set { Set(ref _Date, value); }
        }
        private string _StartPeriod;
        public string StartPeriod
        {
            get { return _StartPeriod; }
            set { Set(ref _StartPeriod, value); }
        }
        private string _EndPeriod;
        public string EndPeriod
        {
            get { return _EndPeriod; }
            set { Set(ref _EndPeriod, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateApodChoiceViewCommand { get; }
        public ApodSearchViewUserControlViewModel(NavigationStore navigationStore, int count, 
            string date, string startPeriod, string endPeriod, ObservableCollection<APODModel> data)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateApodChoiceViewCommand = new NavigateCommand<ApodSearchByCountChoiceUserControlViewModel>
               (new NavigationService<ApodSearchByCountChoiceUserControlViewModel>
               (navigationStore, () => new ApodSearchByCountChoiceUserControlViewModel(navigationStore)));
            if(count > 0 && date == null && startPeriod == null && endPeriod == null)
            {
                _Count = count;
            }
            else if (count <= 0 && date != null && startPeriod == null && endPeriod == null)
            {
                _Date = date;
            }
            else if (count <= 0 && date == null && startPeriod != null && endPeriod != null)
            {
                _StartPeriod = startPeriod;
                _EndPeriod = endPeriod;
            }
            DataSources = data;
        }
    }
}
