namespace FeedbackSystem.UseCases.Comments.Delete;

public record DeleteAdminCommentCommand(int feedbackId) : ICommand<Result>;
