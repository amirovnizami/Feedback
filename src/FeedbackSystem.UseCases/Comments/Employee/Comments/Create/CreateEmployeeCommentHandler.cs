using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;
using FeedbackSystem.UseCases.Security;

namespace FeedbackSystem.UseCases.Comments.Employee.Comments.Create;

public class CreateEmployeeCommentHandler(
  IRepository<Comment> repository,
  IRepository<Feedback> feedbackRepository)
  : ICommandHandler<CreateEmployeeCommentCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateEmployeeCommentCommand request, CancellationToken cancellationToken)
  {
    var feedbackSpecification = new FeedbackByLoginId(request.loginId);
    var result = await feedbackRepository.FirstOrDefaultAsync(feedbackSpecification, cancellationToken);
    if (result == null) return Result.NotFound("Feedback not found");

    var newComment = new Comment(request.comment, result.Id, 1,request.file!);
    var createdItem = await repository.AddAsync(newComment, cancellationToken);
    return Result.Success(createdItem.Id);
  }
}
