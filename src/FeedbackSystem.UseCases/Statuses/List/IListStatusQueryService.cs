using FeedbackSystem.Core.StatusAgrregate;
using FeedbackSystem.Core.StatusAgrregate.Specifications;

namespace FeedbackSystem.UseCases.Statuses.List;

public interface IListStatusQueryService
{
  Task<List<Status>> ListAsync(StatusListSpec spec);
}
