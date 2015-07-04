using NewsFeedServices.Components;
using NewsFeedServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsFeedServices.Controllers
{
    public class NewsController : ApiController
    {
        INewsFeed _newsFeed;

        public NewsController() :
            this(new NewsFeed())
        {
        }

        public NewsController(INewsFeed newsFeed)
        {
            _newsFeed = newsFeed;
        }

        [HttpGet]
        public HttpResponseMessage Rss(string category)
        {
            List<NewsDto> news = _newsFeed.GetFeed(category);

            //forcing to send back response in Xml format
            HttpResponseMessage resp = Request.CreateResponse<List<NewsDto>>(HttpStatusCode.OK, value: news,
                formatter: Configuration.Formatters.XmlFormatter);

            return resp;
        }

        [HttpGet]
        public HttpResponseMessage Rest(string cat)
        {
            List<NewsDto> news = _newsFeed.GetFeed(cat);

            //forcing to send back response in Json format
            HttpResponseMessage resp = Request.CreateResponse<List<NewsDto>>(HttpStatusCode.OK, value: news,
                formatter: Configuration.Formatters.JsonFormatter);

            return resp;
        }
    }
}
