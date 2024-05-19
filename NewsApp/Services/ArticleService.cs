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

        public async Task<(int, List<Article>)> GetArticalsAsync(string searchedText, DateTime fromDate, DateTime toDate, int articalesNumber = 25, SortBys sortBy = SortBys.Relevancy, Languages lang = Languages.EN)
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
                return (articlesResponse.TotalResults, articlesResponse.Articles);
            }
            else
            {
                ExceptionMessage.Invoke(articlesResponse.Error.Message);
                return (0, null);
            }
        }
    }
}
