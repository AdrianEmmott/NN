using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace webApi.Models
{
    public class ArticleTagModel
    {
        public ArticleTagModel()
        {
            TagIds = new List<int>();
            Tags = new List<TagModel>();
        }

        [JsonProperty("id")]
        public int ArticleId { get; set; }

        [JsonProperty("tagIds")]
        public List<int> TagIds { get; set; }

        [JsonProperty("tags")]
        public List<TagModel> Tags { get; set; }
    }
}