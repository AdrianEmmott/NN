using System.Collections.Generic;
using webApi.Models;

namespace webApi.Contracts
{
    public interface ITagService
    {
        List<TagModel> GetAllTags();

        ArticleTagModel GetTagsByArticleId(int articleId);
    }
}