using Microsoft.Extensions.DependencyInjection;
using NASA_APIs.WPF.ViewModels;

namespace NASA_APIs.WPF
{
    public class ServiceLocator
    {
        public MainWindowViewModel MainModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
