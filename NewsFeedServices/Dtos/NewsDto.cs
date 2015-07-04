using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsFeedServices.Dtos
{
    public class NewsDto
    {
        public long NewsId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Descripion { get; set; }
        public System.DateTime PublishedDate { get; set; }

    }
}