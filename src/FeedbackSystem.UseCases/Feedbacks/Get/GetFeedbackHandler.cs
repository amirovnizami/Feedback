using AutoMapper;
using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;
using FeedbackSystem.UseCases.Comments;

namespace FeedbackSystem.UseCases.Feedbacks.Get;

public class GetFeedbackHandler(
  IReadRepository<Feedback> repository, 
  CommentService commentService) 
  : IQueryHandler<GetFeedbackQuery, Result<FeedbackDto>>
{
  public async Task<Result<FeedbackDto>> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
  {
    var spec = new FeedbackByIdSpec(request.id);
    var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (entity == null) return Result.NotFound("Feedback not found");

    var commentDtos = new List<CommentDto>();

    foreach (var comment in entity.Comments)
    {
      var dto = await commentService.CreateCommentDtoAsync(comment);
      commentDtos.Add(dto);
    }

    return new FeedbackDto(
      entity.LoginId, entity.FirstName, entity.LastName, 
      entity.Email, entity.BranchId, commentDtos);
  }
}

