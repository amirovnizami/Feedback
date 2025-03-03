namespace FeedbackSystem.UseCases.Feedbacks.Get;

public record GetFeedbackQuery(int id) : IQuery<Result<FeedbackDto>>;
