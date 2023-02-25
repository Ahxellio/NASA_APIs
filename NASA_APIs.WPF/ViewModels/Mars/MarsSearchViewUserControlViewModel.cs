using NASA_APIs.DAL.Entities;
using NASA_APIs.WPF.Infrastructure;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels.Base;
using NASA_APIs.WPF.Views.UserControls.Mars;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NASA_APIs.WPF.ViewModels.Mars
{
    public class MarsSearchViewUserControlViewModel : BaseVM
    {
        private DAL.Entities.Photo _Photo;
        public DAL.Entities.Photo Photo
        {
            get { return _Photo; }
            set { Set(ref _Photo, value); }
        }
        public ObservableCollection<DAL.Entities.Photo> PhotosValues { get; set; } = new();
        private int _Sol;
        public int Sol
        {
            get { return _Sol; }
            set { Set(ref _Sol, value); }
        }
        private int _Page;
        public int Page
        {
            get { return _Page; }
            set { Set(ref _Page, value); }
        }
        private string _Camera;
        public string Camera
        {
            get { return _Camera; }
            set { Set(ref _Camera, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public MarsSearchViewUserControlViewModel(NavigationStore navigationStore, int sol, int page, string camera, ObservableCollection<DAL.Entities.Photo> photos)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            _Sol = sol;
            if (page != 0 && camera is null)
            {
                _Page = page;
            }
            else if(page == 0 && camera is not null)
            {
                _Camera = camera;
            }
            PhotosValues = photos;
        }
    }
}
