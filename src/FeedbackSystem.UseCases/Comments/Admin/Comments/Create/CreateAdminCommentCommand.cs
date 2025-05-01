namespace FeedbackSystem.UseCases.Comments.Admin.Comments.Create;

public record CreateAdminCommentCommand(string feedbackId, string comment,string? filename) : ICommand<Result<int>>;
