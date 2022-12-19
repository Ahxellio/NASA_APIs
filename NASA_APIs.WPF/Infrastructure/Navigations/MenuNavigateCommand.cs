using NASA_APIs.WPF.Infrastructure.Base;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels;
using NASA_APIs.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_APIs.WPF.Infrastructure.Navigations
{
    public class MenuNavigateCommand : Command
    {
        private readonly MenuViewModel _viewModel;
        private readonly NavigationService<BaseVM> _navigationService;

        public MenuNavigateCommand(MenuViewModel viewModel, NavigationService<BaseVM> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
