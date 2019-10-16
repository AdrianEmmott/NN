using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace webApi.Models
{
    public class ArticleCategoryModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("categories")]
        public List<ArticleCategoryModel> Categories { get; set; }
    }
}