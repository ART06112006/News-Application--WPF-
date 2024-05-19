using NewsApp.Infrastructure;
using NewsApp.Services;
using NewsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Commands
{
    public class SearchArticlesCommand : BaseCommand
    {
        public override async void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;

            if (viewModel != null)
            {
                var articleService = (ArticleService)(AppServiceProvider.ServiceProvider.GetService(typeof(ArticleService)));

                var result = await articleService.GetArticlesAsync(viewModel.SearchedText, viewModel.FromDate, viewModel.ToDate, viewModel.SortBy, viewModel.Lang);

                viewModel.UpdateUI(result);
            }
        }
    }
}
