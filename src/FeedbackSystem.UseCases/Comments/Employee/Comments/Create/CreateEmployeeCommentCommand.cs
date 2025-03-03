namespace FeedbackSystem.UseCases.Comments.Employee.Comments.Create;

public record CreateEmployeeCommentCommand(string loginId, int? userId ,string comment,string? file) : ICommand<Result<int>>;
