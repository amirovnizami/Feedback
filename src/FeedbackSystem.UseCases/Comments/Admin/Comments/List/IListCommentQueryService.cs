

using FeedbackSystem.Core.CommentAggregate;

namespace FeedbackSystem.UseCases.Comments.Admin.Comments.List;

public interface IListCommentQueryService
{
  Task<List<Comment>> ListAsync(CommentByLoginId commentListSpec);
}
