using NewsFeedServices.Dtos;
using NewsFeedServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NewsFeedServices.Components
{
    public class NewsFeed : INewsFeed
    {
        #region  " PRIVATE VARAIBLE "

        NewsFeedEntities newsFeedContext;

        #endregion

        #region " CONSTRUCTOR "

        public NewsFeed()
        {
            newsFeedContext = new NewsFeedEntities();
        }

        #endregion

        #region " PUBLIC METHOD "

        public List<NewsDto> GetFeed(string category)
        {
            var feed = newsFeedContext.News.Include(x => x.Category)
                                .Where(x => x.Category.CategoryName == category && x.IsPublished)
                                .OrderByDescending(x => x.PublishedDate)
                                .Select(n => n).Take(5).AsEnumerable()
                                 .Select(n => new NewsDto
                                  {
                                      NewsId = n.NewsId,
                                      CategoryId = Convert.ToInt32(n.CategoryId),
                                      CategoryName = n.Category.CategoryName,
                                      Descripion = n.Descripion,
                                      PublishedDate = Convert.ToDateTime(n.PublishedDate)
                                  }).ToList<NewsDto>();

            return feed;
        }

        #endregion
    }
}