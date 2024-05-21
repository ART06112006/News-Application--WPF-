using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace NewsApp.Services
{
    public class ArticleService
    {
        public string APIKey { get; set; }
        public Action<string> ExceptionMessage { get; set; }

        public async Task<List<Article>?> GetArticlesAsync(string searchedText, DateTime fromDate, DateTime toDate, SortBys sortBy = SortBys.Relevancy, Languages lang = Languages.EN, int articalesNumber = 100)
        {
            try
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
                    return await Task.Run(() =>
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
                    });
                }
                else
                {
                    ExceptionMessage?.Invoke(articlesResponse.Error.Message);
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                ExceptionMessage?.Invoke("Unable to complete the request! Please, check your internet connection.");
                return null;
            }
            catch (Exception ex)
            {
                ExceptionMessage?.Invoke(ex.Message);
                return null;
            }
        }
    }
}
