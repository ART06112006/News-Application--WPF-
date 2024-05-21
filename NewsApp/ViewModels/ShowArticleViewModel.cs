using NewsAPI.Models;
using NewsApp.Commands;
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
    }
}
