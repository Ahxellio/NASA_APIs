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
    public class MarsUserControlViewModel : BaseVM
    {
        public ICommand NavigateMarsCommand { get; }
        public MarsUserControlViewModel()
        {
            //NavigateMarsCommand = new NavigateCommand(navigationService);
        }
    }
}
