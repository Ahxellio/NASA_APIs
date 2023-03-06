using NASA_APIs.DAL.Entities;
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
using System.Windows;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.Techport
{
    public class TechPortViewUserControlViewModel : BaseVM
    {
        private Projects _SelectedItem;
        public Projects SelectedItem
        {
            get { return _SelectedItem; }
            set { Set(ref _SelectedItem, value); }
        }
        public ObservableCollection<Projects> TechPortValues { get; } = new();
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
        public TechPortViewUserControlViewModel(NavigationStore navigationStore, string date, int id, ObservableCollection<Projects> techportvalues)
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
            TechPortValues = techportvalues;
        }
    }
}
