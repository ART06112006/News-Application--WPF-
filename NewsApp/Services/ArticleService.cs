using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Services
{
    public class ArticleService
    {
        private readonly string _apiKey;
        private Action<string> ExceptionMessage;


        public ArticleService(string apiKey, Action<string> exceptionMessage)
        {
            _apiKey = apiKey;
            ExceptionMessage = exceptionMessage;
        }

        public async Task<List<Article>?> GetArticlesAsync(string searchedText, DateTime fromDate, DateTime toDate, SortBys sortBy = SortBys.Relevancy, Languages lang = Languages.EN, int articalesNumber = 25)
        {
            var newsApiClient = new NewsApiClient(_apiKey);

            var articlesResponse = await newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                Q = searchedText,
                SortBy = sortBy,
                Language = lang,
                From = fromDate,
                To = toDate,
                PageSize = articalesNumber
            });

            if (articlesResponse.Status == Statuses.Ok)
            {
                return articlesResponse.Articles;
            }
            else
            {
                ExceptionMessage.Invoke(articlesResponse.Error.Message);
                return null;
            }
        }
    }
}
