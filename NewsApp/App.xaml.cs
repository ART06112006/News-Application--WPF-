using Microsoft.Extensions.DependencyInjection;
using NewsApp.Infrastructure;
using NewsApp.Services;
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
            var articleService = AppServiceProvider.ServiceProvider.GetService<ArticleService>();
            articleService.APIKey = "a7f99612c2864e20bb2aabe06b2a8055";
            articleService.ExceptionMessage = x => MessageBox.Show(x, "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            var mainView = AppServiceProvider.ServiceProvider.GetService<MainView>();
            mainView.Show();
        }
    }

}
