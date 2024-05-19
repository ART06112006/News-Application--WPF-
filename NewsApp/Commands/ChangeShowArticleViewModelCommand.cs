using NewsAPI.Models;
using NewsApp.Infrastructure;
using NewsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Commands
{
    public class ChangeShowArticleViewModelCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var view = (ShowArticleView)(AppServiceProvider.ServiceProvider.GetService(typeof(ShowArticleView)));
            view.ViewModel.Article = parameter as Article;
            view.ShowDialog();
        }
    }
}
