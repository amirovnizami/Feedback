using FluentValidation;

namespace FeedbackSystem.Web.Employee.Comments.Create;

public class CreateCommentValidator : Validator<CreateCommentRequest>
{
  public CreateCommentValidator()
  {
    RuleFor(c => c.loginId)
      .NotEmpty().WithMessage("Enter feedback ID");
    RuleFor(c => c.Comment)
      .NotEmpty().WithMessage("Comment cannot be empty");
  }
}
