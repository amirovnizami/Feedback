using FluentValidation;

namespace FeedbackSystem.Web.Employee.Feedbacks.Create;

public class CreateFeedbackValidator : Validator<CreateFeedbackRequest>
{
  public CreateFeedbackValidator()
  {
    RuleFor(f => f.Email)
      .EmailAddress().WithMessage("Invalid email address");
    RuleFor(f => f.BranchId)
      .NotEmpty().WithMessage("Branch id is required")
      .GreaterThan(0).WithMessage("Branch id must be greater than 0");
    RuleFor(f => f.BranchId)
      .NotEmpty().WithMessage("Status id is required")
      .GreaterThan(0).WithMessage("Status id must be greater than 0");
  }
}
