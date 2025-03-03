using FluentValidation;

namespace FeedbackSystem.Web.Employee.Comments.Delete;

public class DeleteCommentValidator : Validator<DeleteCommentRequest>
{
  public DeleteCommentValidator()
  {
    RuleFor(c => c.LoginId).NotEmpty().WithMessage("LoginId ID cannot be empty");
  }
}
