using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace webApi.Models
{
    public class ArticleModel
    {
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

        [JsonProperty("tags")]
        public List<int> Tags { get; set; }
    }
}