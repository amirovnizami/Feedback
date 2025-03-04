

using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.CommentAggregate.Specification;

namespace FeedbackSystem.UseCases.Comments.Admin.Comments.List;

public interface IListCommentQueryService
{
  Task<List<Comment>> ListAsync(CommentByLoginId commentListSpec);
}
