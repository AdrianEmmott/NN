using System;
using System.Collections.Generic;
using webApi.Models.Tags;

namespace webApi.Data.Interfaces.Articles
{
    public interface IArticleTagsRepository
    {
        List<ArticleTagModel> GetArticleTags(Guid articleId);
    }
}