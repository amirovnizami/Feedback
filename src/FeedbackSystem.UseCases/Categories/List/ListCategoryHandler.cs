using AutoMapper;
using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.CategoryAggregate.Specifications;
using FeedbackSystem.UseCases.Branches.List;
using FeedbackSystem.UseCases.Branches;

namespace FeedbackSystem.UseCases.Categories.List;

public class ListCategoryHandler(IListCategoryQueryService _query, IMapper mapper)
  : IQueryHandler<ListCategoryQuery, Result<List<CategoryDto>>>
{
  public async Task<Result<List<CategoryDto>>> Handle(ListCategoryQuery request, CancellationToken cancellationToken)
  {
    var specification = new CategoryListSpec(request.id, request.name);
    var result = await _query.ListAsync(specification);
    if (result.Count == 0)
    {
      return Result.NotFound("Category not found");
    }

    return Result.Success(mapper.Map<List<CategoryDto>>(result));
  }
}
