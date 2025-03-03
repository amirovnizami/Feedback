using FluentValidation;

namespace FeedbackSystem.Web.Categories.Create;

public class CreateCategoryValidator : Validator<CreateCategoryRequest>
{
  public CreateCategoryValidator()
  {
    RuleFor(c => c.Name)
      .NotEmpty()
      .WithMessage("Name is required")
      .MinimumLength(2);
  }
}
