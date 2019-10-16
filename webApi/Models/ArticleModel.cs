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
        [JsonConverter(typeof(JSONStringToListIntConvertor))]
        public List<int> Tags{ get;set; }
    }
}

public class JSONStringToListIntConvertor : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        // this converter can handle converting some JSON to a List<int>
        return objectType == typeof(List<int>);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Convert a comma separated string to a list of ints
        return reader.Value.ToString().Split(',').Select(int.Parse).ToList();
    }

    public override bool CanWrite
    {
        get { return false; }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}