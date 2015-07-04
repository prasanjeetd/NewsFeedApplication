using NewsFeedServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeedServices.Components
{
    public interface INewsFeed
    {
        List<NewsDto> GetFeed(string category);
    }
}