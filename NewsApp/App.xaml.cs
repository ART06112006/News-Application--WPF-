using Microsoft.Extensions.DependencyInjection;
using NewsApp.Infrastructure;
using NewsApp.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace NewsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppServiceProvider.Initialize();
            var mainView = AppServiceProvider.ServiceProvider.GetService<MainView>();
            mainView.Show();
        }
    }

}
