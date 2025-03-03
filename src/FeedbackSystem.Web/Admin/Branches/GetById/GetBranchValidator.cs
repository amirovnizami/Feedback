using FastEndpoints;
using FluentValidation;

namespace FeedbackSystem.Web.Branches;

public class GetBranchValidator : Validator<GetBranchByIdRequest>
{
  public GetBranchValidator()
  {
    RuleFor(x => x.BranchId)
      .GreaterThan(0);
  }
}
