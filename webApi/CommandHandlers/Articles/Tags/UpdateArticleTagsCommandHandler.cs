using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using webApi.Commands.Tags;
using webApi.Data.Entities;
using webApi.Models.Tags;

namespace webApi.CommandHandlers.Publisher
{
    public class UpdateArticleTagsCommandHandler : IRequestHandler<UpdateArticleTagsCommand>
    {
        public Task<Unit> Handle(UpdateArticleTagsCommand request, CancellationToken cancellationToken)
        {
            using (var context = new NewsContext())
            {
                // get list of existing article tags in db
                List<ArticleTagModel> existingRecords =
                context.ArticleTags
                    .Where(x => x.ArticleId == request.ArticleTags.FirstOrDefault().ArticleId)
                    .Select(y => new ArticleTagModel
                    {
                        ArticleId = y.ArticleId,
                        TagId = y.TagId
                    })
                    .ToList();

                // records to delete (not in incoming model but in db)
                List<ArticleTagModel> recordsToDelete = 
                    existingRecords.Where(existing => !request.ArticleTags
                                    .Select(modelRecords => modelRecords.TagId)
                                    .ToList()
                                    .Contains(existing.TagId))
                                .Select(existing => existing)
                                .ToList();

                // records to insert (not in the db)   
                List<ArticleTagModel> recordsToInsert = 
                    request.ArticleTags.Where(newRecord => !existingRecords
                                    .Select(existing => existing.TagId)
                                    .ToList()
                                    .Contains(newRecord.TagId))
                                .Select(newRecord => newRecord)
                                .ToList();

                                
            }

            return null;
        }
    }
}