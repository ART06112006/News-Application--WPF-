using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsApp.ViewModels
{
    public class ShowArticleViewModel : BaseViewModel
    {
        private Article _article;
        public Article Article
        {
            get { return _article; }
            set
            {
                _article = value;
                OnPropertyChanged();
            }
        }

        public ICommand ExitCommand { get; private set; }
        public Action CloseView { get; set; }

        public ShowArticleViewModel(ExitShowArticleViewCommand exitShowArticleViewCommand)
        {
            ExitCommand = exitShowArticleViewCommand;
        }
    }
}
