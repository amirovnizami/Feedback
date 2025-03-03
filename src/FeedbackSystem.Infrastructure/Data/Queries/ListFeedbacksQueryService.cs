using FeedbackSystem.Core.FeedbackAgrregate.Specifications;
using FeedbackSystem.UseCases.Feedbacks.List;

namespace FeedbackSystem.Infrastructure.Data.Queries
{
  public class ListFeedbacksQueryService(AppDbContext db) : IListFeedbackQueryService
  {
    public Task<List<Feedback>> ListAsync(FeedbackListSpec feedbackListSpec)
    {
      var feedbacks = db.Feedbacks
        .Include(f => f.Comments)
        .ToListAsync();
      return feedbacks;
    }
  }
}
