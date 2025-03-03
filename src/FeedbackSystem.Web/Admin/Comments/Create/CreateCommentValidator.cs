using FluentValidation;

namespace FeedbackSystem.Web.Admin.Comments.Create;

public class CreateCommentValidator : Validator<CreateCommentRequest>
{
  public CreateCommentValidator()
  {
    RuleFor(c => c.feedbackId)
      .NotEmpty().WithMessage("Enter feedback ID")
      .GreaterThan(0).WithMessage("Enter correct feedback ID");
    RuleFor(c => c.Comment)
      .NotEmpty().WithMessage("Comment cannot be empty");
  }
}
