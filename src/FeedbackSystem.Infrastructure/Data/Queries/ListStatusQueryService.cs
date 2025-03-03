using FeedbackSystem.Core.StatusAgrregate;
using FeedbackSystem.Core.StatusAgrregate.Specifications;
using FeedbackSystem.UseCases.Statuses.List;

namespace FeedbackSystem.Infrastructure.Data.Queries;

public class ListStatusQueryService(AppDbContext db) : IListStatusQueryService
{
  public Task<List<Status>> ListAsync(StatusListSpec spec)
  {
    return db.Statuses.ToListAsync(spec);
  }
}
