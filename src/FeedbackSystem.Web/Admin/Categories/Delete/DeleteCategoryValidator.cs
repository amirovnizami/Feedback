using FluentValidation;

namespace FeedbackSystem.Web.Categories.Delete;

public class DeleteCategoryValidator : Validator<DeleteCategoryRequest>
{
  public DeleteCategoryValidator()
  {
    RuleFor(x => x.CategoryId)
      .GreaterThan(0).WithMessage("Category Id must be greater than 0")
      .NotEmpty().WithMessage("Category Id cannot be empty");
  }
}
