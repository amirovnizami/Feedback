using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.BranchAggregaet;

namespace FeedbackSystem.UseCases.Branches.Get;

public class GetBranchHandler(IReadRepository<Branch> _repository)
  : IQueryHandler<GetBranchQuery, Result<BranchDto>>
{
  public async Task<Result<BranchDto>> Handle(GetBranchQuery request, CancellationToken cancellationToken)
  {
    var spec = new BranchByIdSpec(request.BranchId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new BranchDto(entity.Id, entity.Name, entity.CategoryId);
  }
}
