using System.Collections.Generic;
using webApi.Models;

namespace webApi.Contracts
{
    public interface ITagService
    {
        List<TagModel> GetFlattenedTags(List<TagModel> model);
        
        List<TagModel> GetAllTags();

        ArticleTagModel GetTagsByArticleId(int articleId);

        void UpdateArticleTags(ArticleTagModel model);
    }
}