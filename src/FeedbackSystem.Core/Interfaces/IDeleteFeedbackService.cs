using FeedbackSystem.Core.FeedbackAgrregate;

namespace FeedbackSystem.Core.Interfaces;

public interface IDeleteFeedbackService
{
  public Task<Result> DeleteFeedback(string loginId);
}
