using FluentValidation;

namespace FeedbackSystem.Web.Branches.Update;

public class UpdateBranchValidator : Validator<UpdateBranchRequest>
{
  public UpdateBranchValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required")
      .MinimumLength(2)
      .MaximumLength(50);
    RuleFor(b => b.BranchId)
      .NotEmpty()
      .WithMessage("Branch Id is required")
      .GreaterThan(0);
  }
}
