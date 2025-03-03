using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;
using FeedbackSystem.Core.StatusAgrregate.Specifications;

namespace FeedbackSystem.UseCases.Feedbacks.List;

public interface IListFeedbackQueryService
{
  Task<List<Feedback>> ListAsync(FeedbackListSpec feedbackListSpec);
}
