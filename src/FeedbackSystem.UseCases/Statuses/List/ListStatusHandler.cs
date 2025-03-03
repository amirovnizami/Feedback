using AutoMapper;
using FeedbackSystem.Core.StatusAgrregate;
using FeedbackSystem.Core.StatusAgrregate.Specifications;

namespace FeedbackSystem.UseCases.Statuses.List;

public class ListStatusHandler(IListStatusQueryService _query, IMapper _mapper) :
  IQueryHandler<ListStatusQuery, Result<List<StatusDto>>>
{
  public async Task<Result<List<StatusDto>>> Handle(ListStatusQuery request, CancellationToken cancellationToken)
  {
    var specification = new StatusListSpec(request.id, request.name);
    var result = await _query.ListAsync(specification);
    if (result.Count == 0)
    {
      return Result.NotFound("Status not found");
    }

    return Result.Success(_mapper.Map<List<StatusDto>>(result));
  }
}
