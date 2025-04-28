using System.Windows.Input;

namespace FeedbackSystem.UseCases.Feedbacks.Delete;

public record DeleteFeedbackCommand(string loginId) : ICommand<Result>;
