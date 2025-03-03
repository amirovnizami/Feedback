using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.Core.CategoryAggregate.Specifications;

namespace FeedbackSystem.UseCases.Categories.Create;

public class CreateCategoryHandler(IRepository<Category> _repository)
  : ICommandHandler<CreateCategoryCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
  {
    var exisitingCategoryName =
      await _repository.FirstOrDefaultAsync(new CategoryByNameSpec(request.NewName), cancellationToken);
    if (exisitingCategoryName is not null)
    {
      return Result.Conflict("Category already exists");
    }

    var newCategory = new Category(request.NewName);
    var createdItem = await _repository.AddAsync(newCategory, cancellationToken);
    return Result.Success(createdItem.Id);
  }
}
