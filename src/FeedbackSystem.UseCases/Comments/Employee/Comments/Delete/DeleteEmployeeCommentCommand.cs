namespace FeedbackSystem.UseCases.Comments.Employee.Comments.Delete;

public record DeleteEmployeeCommentCommand(string loginId) : ICommand<Result>;
