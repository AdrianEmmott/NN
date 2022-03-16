using System;
using System.Collections.Generic;
using System.Linq;
using webApi.Data.Interfaces.Articles;
using webApi.Models.Tags;

namespace webApi.Data.Repositories.Articles.Tags
{
    public class ArticleTagsRepository : BaseRepository, IArticleTagsRepository
    {
        public List<ArticleTagModel> GetArticleTags(Guid articleId)
        {
            var results = Context
            .ArticleTags
            .Where(x => x.ArticleId == articleId)
            .Select(x => new ArticleTagModel
            {
                ArticleId = x.ArticleId,
                TagId = x.TagId
            })
            .ToList();
            
            return results;
        }
    }
}