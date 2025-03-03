using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.Core.CategoryAggregate.Specifications;

namespace FeedbackSystem.UseCases.Categories.Get;

public class GetCategoryHandler(IReadRepository<Category> _repository)
  : IQueryHandler<GetCategoryQuery, Result<CategoryDto>>
{
  public async Task<Result<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
  {
    var spec = new CategoryByIdSpec(request.CategoryId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new CategoryDto(entity.Id, entity.Name);
  }
}
