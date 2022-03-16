using System;
using System.Collections.Generic;

namespace webApi.Models.Articles
{
    public class ArticleModel
    {
        public ArticleModel() 
        {
            Attachments = new List<string>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Summary { get; set; }

        public string HeaderImage { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public bool Published { get; set; }

        public DateTime? PublishDate { get; set; }

        public int? Views { get; set; }

        public List<int> TagIds { get; set; }

        public List<string> Attachments{ get; set; }
    }
}