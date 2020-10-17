using Newtonsoft.Json;
using System;
using System.Globalization;

namespace webApi.Models
{
    public class ArticleSummaryModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("publishDate")]
        public DateTime PublishDate { get; set; }

        [JsonProperty("formattedPublishDate")]
        public string FormattedPublishDate 
        {
            get 
            {
                string formattedDate = PublishDate.ToString("MMM", CultureInfo.InvariantCulture) + " " + PublishDate.Day.ToString();
                return formattedDate;
            }
        }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("headerImage")]
        public string HeaderImage { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }
}