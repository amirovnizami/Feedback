using FluentValidation;

namespace FeedbackSystem.Web.Users.Register;

public class RegisterValidator : Validator<RegisterRequest>
{
  public RegisterValidator()
  {
    RuleFor(u => u.FirstName)
      .NotEmpty().WithMessage("First name cannot be empty.")
      .MaximumLength(15).WithMessage("First name cannot be more than 15 characters.");
    RuleFor(u => u.LastName)
      .NotEmpty().WithMessage("Last name cannot be empty.")
      .MaximumLength(15).WithMessage("Last name cannot be more than 15 characters.");
  }
}
