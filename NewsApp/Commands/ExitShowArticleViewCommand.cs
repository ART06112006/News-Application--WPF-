using NewsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Commands
{
    public class ExitShowArticleViewCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            (parameter as ShowArticleViewModel)?.CloseView();
        }
    }
}
