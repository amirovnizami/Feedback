using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.UseCases.Categories;
using FeedbackSystem.UseCases.Categories.Update;
using FeedbackSystem.UseCases.Branches;
using FeedbackSystem.UseCases.Branches.Update;

namespace FeedbackSystem.UseCases.Contributors.Update;

public class UpdataCategoryHandler(IRepository<Category> _repository)
  : ICommandHandler<UpdateCategoryCommand, Result<CategoryDto>>
{
  public async Task<Result<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
  {
    var exisitingCategory = await _repository.GetByIdAsync(request.id, cancellationToken);
    if (exisitingCategory == null)
    {
      return Result.NotFound();
    }

    exisitingCategory.UpdateName(request.NewName!);

    await _repository.UpdateAsync(exisitingCategory, cancellationToken);

    return new CategoryDto(exisitingCategory.Id,
      exisitingCategory.Name);
  }
}
