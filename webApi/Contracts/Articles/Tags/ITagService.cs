using System.Collections.Generic;
using webApi.Models.Articles.Tags;

namespace webApi.Contracts.Articles.Tags
{
    public interface ITagService
    {
        List<TagModel> GetFlattenedTags(List<TagModel> model = null, bool keepChildren = false);

        List<TagModel> GetAllTags();

        ArticleTagModel GetTagsByArticleId(int articleId);

        void CreateArticleTags(ArticleTagModel model);
        
        void UpdateArticleTags(ArticleTagModel model);

        List<string> TagPathToTagPathList(string tagPath);

        string SetTagPath(List<string> tagPaths);

        bool TagPathRootSearch(List<string> tagPaths);

        bool TagPathRootSearch(string tagPath);

        TagModel FindTagByPath(string tagPath);
    }
}