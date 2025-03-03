using FluentValidation;

namespace FeedbackSystem.Web.Admin.Comments.Delete;

public class DeleteCommentValidator : Validator<DeleteCommentRequest>
{
  public DeleteCommentValidator()
  {
    RuleFor(c => c.FeedbackId).NotEmpty().WithMessage("Comment ID cannot be empty");
  }
}
