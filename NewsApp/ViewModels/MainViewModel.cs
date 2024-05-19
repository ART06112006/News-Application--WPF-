using NewsAPI.Constants;
using NewsAPI.Models;
using NewsApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Article> _articles;
        public ObservableCollection<Article> Articles
        {
            get { return _articles; }
            set
            {
                if (_articles != value)
                {
                    _articles = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _resultsCount;
        public int ResultsCount
        {
            get { return _resultsCount; }
            set
            {
                _resultsCount = value;
                OnPropertyChanged();
            }
        }

        private string _searchedText;
        public string SearchedText
        {
            get { return _searchedText; }
            set
            {
                if (_searchedText != value)
                {
                    _searchedText = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _fromDate;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                if (_fromDate != value)
                {
                    _fromDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _toDate;
        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                if (_toDate != value)
                {
                    _toDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private SortBys _sortBy;
        public SortBys SortBy
        {
            get { return _sortBy; }
            set
            {
                if (_sortBy != value)
                {
                    _sortBy = value;
                    OnPropertyChanged();
                }
            }
        }

        private Languages _lang;
        public Languages Lang
        {
            get { return _lang; }
            set
            {
                if (_lang != value)
                {
                    _lang = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SearchCommand { get; private set; }

        public MainViewModel(SearchArticlesCommand searchArticlesCommand)
        {
            SearchCommand = searchArticlesCommand;
        }

        public void UpdateUI(List<Article> articles)
        {
            Articles = new ObservableCollection<Article>(articles);
            ResultsCount = Articles.Count;
        }
    }
}
