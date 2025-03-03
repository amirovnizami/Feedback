using AutoMapper;
using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;
using FeedbackSystem.Core.StatusAgrregate.Specifications;
using FeedbackSystem.UseCases.Statuses;

namespace FeedbackSystem.UseCases.Feedbacks.List;

public class ListFeedbackHandler(IListFeedbackQueryService _query, IMapper mapper)
  : IQueryHandler<ListFeedbackQuery, Result<List<FeedbackDto>>>
{
  public async Task<Result<List<FeedbackDto>>> Handle(ListFeedbackQuery request, CancellationToken cancellationToken)
  {
    var specification = new FeedbackListSpec(request.firstname, request.branchId, request.id);
    var result = await _query.ListAsync(specification);
    if (result.Count == 0)
    {
      return Result.NotFound("Feedback not found");
    }

    return Result.Success(mapper.Map<List<FeedbackDto>>(result));
  }
}
