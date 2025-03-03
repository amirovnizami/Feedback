using FastEndpoints;
using FluentValidation;

namespace FeedbackSystem.Web.Branches;

public class DeleteBranchValidator : Validator<DeleteBranchRequest>
{
  public DeleteBranchValidator()
  {
    RuleFor(x => x.BranchId)
      .GreaterThan(0)
      .NotEmpty()
      .WithMessage("Please specify a valid branch ID");
  }
}
