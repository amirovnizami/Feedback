using FeedbackSystem.Core.CommentAggregate;

namespace FeedbackSystem.UseCases.Comments.Employee.Comments.List;

public interface IListEmployeeCommentQueryService
{
  Task<List<Comment>> ListAsync(CommentByLoginId commentListSpec);
}
