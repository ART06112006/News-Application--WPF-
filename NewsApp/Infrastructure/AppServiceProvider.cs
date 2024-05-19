using Microsoft.Extensions.DependencyInjection;
using NewsApp.Services;
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

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
