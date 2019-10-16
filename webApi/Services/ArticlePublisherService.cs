using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using webApi.Contracts;
using webApi.Models;

namespace webApi.Services
{
    public class ArticlePublisherService : ArticleService, IArticlePublisherService
    {
        private const string Path = "Data/articles.json";

        public ArticlePublisherService()
        {

        }

        public void CreateArticle(ArticlePublisherModel model)
        {

        }

        public void UpdateArticle(ArticlePublisherModel model)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.Formatting = Formatting.Indented;

            string json = File.ReadAllText(Path);

            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json, serializerSettings);

            JArray articlesArray = (JArray)jsonObj;

            var newjToken = JToken.FromObject(model);

            articlesArray
                .Where(x => x["id"].Value<int>() == model.Id)
                .FirstOrDefault().Replace(newjToken);

            jsonObj = articlesArray;

            string output = Newtonsoft.Json.JsonConvert
                    .SerializeObject(jsonObj, serializerSettings.Formatting, serializerSettings);

            File.WriteAllText(Path, output);
        }
    }
}