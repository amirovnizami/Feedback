using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.CommentAggregate.Specification;

namespace FeedbackSystem.UseCases.Comments.Employee.Comments.List;

public interface IListEmployeeCommentQueryService
{
  Task<List<Comment>> ListAsync(CommentByLoginId commentListSpec);
}
