using System.Windows.Input;

namespace FeedbackSystem.UseCases.Feedbacks.Delete;

public record DeleteFeedbackCommand(int id) : ICommand<Result>;
