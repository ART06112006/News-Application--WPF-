using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewsApp.Services
{
    public class ArticleService
    {
        public string APIKey { get; set; }
        public Action<string> ExceptionMessage { get; set; }


        //public ArticleService(string apiKey, Action<string> exceptionMessage)
        //{
        //    _apiKey = apiKey;
        //    ExceptionMessage = exceptionMessage;
        //}

        public async Task<List<Article>?> GetArticlesAsync(string searchedText, DateTime fromDate, DateTime toDate, SortBys sortBy = SortBys.Relevancy, Languages lang = Languages.EN, int articalesNumber = 100)
        {
            var newsApiClient = new NewsApiClient(APIKey);

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
                var result = new List<Article>();
                for (int i = 0; i < articlesResponse.Articles.Count; i++)
                {
                    if (articlesResponse.Articles[i].Content != "[Removed]" && articlesResponse.Articles[i].Title != "[Removed]" && articlesResponse.Articles[i].Description != "[Removed]")
                    {
                        if (string.IsNullOrEmpty(articlesResponse.Articles[i].Author))
                        {
                            articlesResponse.Articles[i].Author = "Unknown author";
                        }

                        if (string.IsNullOrEmpty(articlesResponse.Articles[i].Source.Name))
                        {
                            articlesResponse.Articles[i].Source.Name = "Unknown source";
                        }

                        if (string.IsNullOrEmpty(articlesResponse.Articles[i].UrlToImage))
                        {
                            articlesResponse.Articles[i].UrlToImage = "../Images/NotFoundImage.png";
                        }

                        result.Add(articlesResponse.Articles[i]);
                    }
                }   
                return result;
            }
            else
            {
                ExceptionMessage.Invoke(articlesResponse.Error.Message);
                return null;
            }
        }
    }
}
