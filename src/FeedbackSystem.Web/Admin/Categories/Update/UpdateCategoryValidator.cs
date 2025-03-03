using FluentValidation;

namespace FeedbackSystem.Web.Categories.Update;

public class UpdateCategoryValidator : Validator<UpdateCategoryRequest>
{
  public UpdateCategoryValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required")
      .MinimumLength(2)
      .MaximumLength(50);
    RuleFor(c => c.CategoryId)
      .NotEmpty().WithMessage("CategoryId is required");
  }
}
