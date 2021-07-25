using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace webApi.Models.Articles
{
    public class ArticleModel
    {
        public ArticleModel() 
        {
            Attachments = new List<string>();
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subTitle")]
        public string SubTitle { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("headerImage")]
        public string HeaderImage { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("publishDate")]
        public DateTime PublishDate { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("tagIds")]
        public List<int> TagIds { get; set; }

        [JsonProperty("attachments")]
        public List<string> Attachments{ get; set; }
    }
}