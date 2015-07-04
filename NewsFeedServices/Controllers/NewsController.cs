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
        [HttpGet]
        public HttpResponseMessage Rss(string category)
        {
            var customer = new Customer { Id = 1, Name = "Michael" };

            //forcing to send back response in Xml format
            HttpResponseMessage resp = Request.CreateResponse<Customer>(HttpStatusCode.OK, value: customer,
                formatter: Configuration.Formatters.XmlFormatter);

            return resp;
        }

        [HttpGet]
        public HttpResponseMessage Rest(string cat)
        {
            var customer = new Customer { Id = 1, Name = "Michael" };

            //forcing to send back response in Xml format
            HttpResponseMessage resp = Request.CreateResponse<Customer>(HttpStatusCode.OK, value: customer,
                formatter: Configuration.Formatters.JsonFormatter);

            return resp;
        }
    }
}
