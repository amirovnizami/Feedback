using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.CommentAggregate.Specification;
using FeedbackSystem.UseCases.Comments.Admin.Comments.List;

namespace FeedbackSystem.Infrastructure.Data.Queries;

public class ListCommentsQueryService(AppDbContext db) : IListCommentQueryService
{
  public Task<List<Comment>> ListAsync(CommentByLoginId categoryListSpec)
  {
    return db.Comments.ToListAsync(categoryListSpec);
  }
}
