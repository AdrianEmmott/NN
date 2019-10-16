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
    public class ArticleCategoryService : IArticleCategoryService
    {
        private const string Path = "Data/articleCategories.json";

        public ArticleCategoryService()
        {

        }

        public List<ArticleCategoryModel> GetArticleCategories()
        {
            using (StreamReader r = new StreamReader(Path))
            {
                string json = r.ReadToEnd();

                List<ArticleCategoryModel> items =
                    JsonConvert.DeserializeObject<List<ArticleCategoryModel>>(json);
                return items;
            }
        }
    }
}