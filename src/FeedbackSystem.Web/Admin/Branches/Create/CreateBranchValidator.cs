using FluentValidation;
using FluentValidation.Validators;

namespace FeedbackSystem.Web.Branchs.Create;

public class CreateBranchValidator : Validator<CreateBranchRequest>
{
  public CreateBranchValidator()
  {
    RuleFor(b => b.Name)
      .NotEmpty()
      .WithMessage("Name is required")
      .MinimumLength(5);
    RuleFor(b => b.CategoryId)
      .NotEmpty()
      .WithMessage("CategoryId is required");
  }
}
