using System;
using System.Collections.Generic;

#nullable disable

namespace webApi.Data.Entities
{
    public partial class Article
    {
        public Article()
        {
            ArticleTags = new HashSet<ArticleTag>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string HeaderImage { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public bool? Published { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? Views { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
