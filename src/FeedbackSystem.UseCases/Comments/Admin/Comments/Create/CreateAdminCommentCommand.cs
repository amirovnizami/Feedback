namespace FeedbackSystem.UseCases.Comments.Admin.Comments.Create;

public record CreateAdminCommentCommand(int feedbackId, string comment,string filename) : ICommand<Result<int>>;
