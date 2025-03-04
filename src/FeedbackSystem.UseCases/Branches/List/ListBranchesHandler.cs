using AutoMapper;
using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.BranchAggregate.Specifications;

namespace FeedbackSystem.UseCases.Branches.List;

public class ListBranchesHandler(IListBranchesQueryService _query, IMapper mapper)
  : IQueryHandler<ListBranchesQuery, Result<List<BranchDto>>>
{
  public async Task<Result<List<BranchDto>>> Handle(ListBranchesQuery request, CancellationToken cancellationToken)
  {
    var specification = new BranchListSpec(request.Name, request.Category);
    var result = await _query.ListAsync(specification);
    return Result.Success(mapper.Map<List<BranchDto>>(result));
  }
}
