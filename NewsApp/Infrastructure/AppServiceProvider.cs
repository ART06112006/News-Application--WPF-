using Microsoft.Extensions.DependencyInjection;
using NewsApp.Commands;
using NewsApp.Services;
using NewsApp.ViewModels;
using NewsApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Infrastructure
{
    public static class AppServiceProvider
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        public static void Initialize()
        {
            var services = new ServiceCollection();

            //Services
            services.AddSingleton<ArticleService>();

            //Views
            services.AddTransient<MainView>();
            services.AddTransient<ShowArticleView>();

            //ModelViews
            services.AddTransient<MainViewModel>();
            services.AddTransient<ShowArticleViewModel>();

            //Commands
            services.AddTransient<SearchArticlesCommand>();
            services.AddTransient<ChangeShowArticleViewModelCommand>();
            services.AddTransient<ExitShowArticleViewCommand>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
