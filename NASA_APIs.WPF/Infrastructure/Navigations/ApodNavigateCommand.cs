using NASA_APIs.WPF.Infrastructure.Base;
using NASA_APIs.WPF.Services;
using NASA_APIs.WPF.Stores;
using NASA_APIs.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_APIs.WPF.Infrastructure.Navigations
{
    public class ApodNavigateCommand : Command
    {
        private readonly ApodUserControlViewModel _viewModel;
        private readonly NavigationService<MenuViewModel> _navigationService;

        public ApodNavigateCommand(ApodUserControlViewModel viewModel, NavigationService<MenuViewModel> navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
            // Navigate to Menu
        }
    }
}
