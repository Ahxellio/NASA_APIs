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

namespace NASA_APIs.WPF.ViewModels.Techport
{
    public class TechPortViewUserControlViewModel : BaseVM
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { Set(ref _Id, value); }
        }
        private string _Date;
        public string Date
        {
            get { return _Date; }
            set { Set(ref _Date, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public TechPortViewUserControlViewModel(NavigationStore navigationStore, string date, int id)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            if(id > 0 && date is null)
            {
                _Id = id;
            }
            else if (id <= 0 && date is not null)
            {
                _Date = date;
            }
        }
    }
}
