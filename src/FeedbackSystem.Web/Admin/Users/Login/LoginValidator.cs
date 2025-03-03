using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace FeedbackSystem.Web.Users.Login;

public class LoginValidator : Validator<LoginRequest>
{
  public LoginValidator()
  {
    RuleFor(u => u.Email)
      .EmailAddress()
      .NotEmpty().WithMessage("Email address required");
    RuleFor(U => U.Password)
      .NotEmpty().WithMessage("Password required");
  }
}
