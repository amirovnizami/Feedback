using FluentValidation;

namespace FeedbackSystem.Web.Categories.GetById;

public class GetCategoryValidator : Validator<GetCategoryByIdRequest>
{
  public GetCategoryValidator()
  {
    RuleFor(x => x.CategoryId)
      .NotEmpty().WithMessage("Category Id cannot be empty")
      .GreaterThan(0).WithMessage("Category Id must be greater than 0");
  }
}
