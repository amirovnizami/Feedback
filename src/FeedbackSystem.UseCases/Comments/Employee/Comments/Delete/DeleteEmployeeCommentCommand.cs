namespace FeedbackSystem.UseCases.Comments.Delete;

public record DeleteEmployeeCommentCommand(string loginId) : ICommand<Result>;
