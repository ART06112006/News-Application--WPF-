using NewsApp.Infrastructure;
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
            view.ShowDialog();
        }
    }
}
