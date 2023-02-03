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

namespace NASA_APIs.WPF.ViewModels.Mars
{
    public class MarsSearchForSolCameraUserControlViewModel : BaseVM
    {
        private int _Sol;
        public int Sol
        {
            get { return _Sol; }
            set { Set(ref _Sol, value); }
        }
        private string _Camera;
        public string Camera
        {
            get { return _Camera; }
            set { Set(ref _Camera, value); }
        }
        private List<string> _CameraList = new List<string> { "FHAZ", "RHAZ", "MAST", "CHEMCAM", "MAHLI", "MARDI", "NAVCAM", "PANCAM", "MINITES" };
        public List<string> CameraList
        {
            get { return _CameraList; }
            set { Set(ref _CameraList, value); }
        }
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateMarsViewCommand { get; }
        public MarsSearchForSolCameraUserControlViewModel(NavigationStore navigationStore)
        {
            NavigateMenuCommand = new NavigateCommand<MenuViewModel>
               (new NavigationService<MenuViewModel>
               (navigationStore, () => new MenuViewModel(navigationStore)));
            NavigateMarsViewCommand = new NavigateCommand<MarsSearchViewUserControlViewModel>
               (new NavigationService<MarsSearchViewUserControlViewModel>
               (navigationStore, () => new MarsSearchViewUserControlViewModel(navigationStore, _Sol, 0, _Camera)));
        }
    }
}
