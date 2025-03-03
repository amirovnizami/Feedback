namespace FeedbackSystem.UseCases.Comments.Admin.Comments.List;

public record ListCommentQuery(string loginId, int? Skip, int? Take) : IQuery<Result<List<CommentDto>>>
{
}
