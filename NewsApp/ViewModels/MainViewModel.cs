using NewsAPI.Constants;
using NewsAPI.Models;
using NewsApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        private List<SortBys> _sortParametrs;
        public List<SortBys> SortParametrs
        {
            get { return _sortParametrs; }
            set
            {
                _sortParametrs = value;
                OnPropertyChanged();
            }
        }

        private List<Languages> _languages;
        public List<Languages> LanguageOptions
        {
            get { return _languages; }
            set
            {
                _languages = value;
            }
        }

        public ICommand SearchCommand { get; private set; }
        public ICommand ShowMoreInfo { get; private set; }

        public MainViewModel(SearchArticlesCommand searchArticlesCommand, ChangeShowArticleViewModelCommand changeShowArticleView)
        {
            SearchCommand = searchArticlesCommand;
            ShowMoreInfo = changeShowArticleView;
            SortParametrs = new List<SortBys>(Enum.GetValues(typeof(SortBys)) as SortBys[]);
            LanguageOptions = new List<Languages>(Enum.GetValues(typeof(Languages)) as Languages[]);
            Lang = Languages.EN;
            FromDate = DateTime.Now.AddMonths(-1);
            ToDate = DateTime.Now;
        }

        public void UpdateUI(List<Article> articles)
        {
            try
            {
                Articles = new ObservableCollection<Article>(articles);
            }
            catch
            {
                Articles = new ObservableCollection<Article>();
            }

            ResultsCount = Articles.Count;
        }
    }
}
