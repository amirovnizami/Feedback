using AutoMapper;
using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.UseCases.Comments;

namespace FeedbackSystem.UseCases.Feedbacks.Update;

public class UpdateFeedbackHandler(IRepository<Feedback> _repository,IMapper _mapper)
  : ICommandHandler<UpdateFeedbackCommand, Result<FeedbackDto>>
{
  public async Task<Result<FeedbackDto>> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
  {
    var exisitingFeedback = await _repository.GetByIdAsync(request.id, cancellationToken);
    if (exisitingFeedback == null)
    {
      return Result.NotFound();
    }

    exisitingFeedback.UpdateName(request.BranchId!, request.Comment);

    await _repository.UpdateAsync(exisitingFeedback, cancellationToken);
     var commentList = _mapper.Map<IEnumerable<CommentDto>>(exisitingFeedback.Comments);
    return new FeedbackDto(exisitingFeedback.LoginId, exisitingFeedback.FirstName,
      exisitingFeedback.LastName, exisitingFeedback.Email, exisitingFeedback.BranchId,exisitingFeedback.StatusId,exisitingFeedback.CreatedDate,
      commentList);
  }
}
