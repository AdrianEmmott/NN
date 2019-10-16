using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using webApi.Contracts;
using webApi.Models;

namespace webApi.Services
{
    public class ArticleService : IArticleService
    {
        private const string Path = "Data/articles.json";

        public ArticleService()
        {

        }

        public List<ArticleModel> GetArticles()
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();

                List<ArticleModel> items =
                    JsonConvert.DeserializeObject<List<ArticleModel>>(json);
                return items;
            }
        }

        public List<ArticleModelSummary> GetArticlesSummary()
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();

                List<ArticleModelSummary> items =
                    JsonConvert.DeserializeObject<List<ArticleModelSummary>>(json);
                return items;
            }
        }

        public ArticleModel GetArticle(int id)
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();

                var model =
                    JsonConvert.DeserializeObject<List<ArticleModel>>(json)
                    .Where(x => x.Id == id).FirstOrDefault();

                if (model != null)
                {
                    UpdateViewCount(id);
                }

                return model;
            }
        }

        public void UpdateViewCount(int id)
        {
            string json = File.ReadAllText(Path);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            JArray articlesArray = (JArray)jsonObj;

            int currentViewCount = articlesArray
                                    .FirstOrDefault(x => x["id"].Value<int>() == id)["views"].Value<int>();

            int newViewCount = currentViewCount;
            newViewCount++;

            articlesArray.FirstOrDefault(x => x["id"].Value<int>() == id)["views"] = newViewCount;

            jsonObj = articlesArray;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(Path, output);
        }
    }
}