using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace webApi.Models
{
    public class TagModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("showInNav")]
        public bool ShowInNav { get; set; }

        [JsonProperty("sortOrder")]
        public int SortOrder { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("tags")]
        public List<TagModel> Tags { get; set; }
    }
}