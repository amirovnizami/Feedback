namespace FeedbackSystem.UseCases.Comments.Employee.Comments.List;

public record ListEmployeeCommentQuery(string loginId, int? Skip, int? Take) : IQuery<Result<List<CommentDto>>>
{
}
