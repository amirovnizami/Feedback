using AutoMapper;
using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;
using FeedbackSystem.UseCases.Comments;

namespace FeedbackSystem.UseCases.Feedbacks.Get;

public class GetFeedbackHandler(
  IReadRepository<Feedback> repository,
  IMapper mapper,
  CommentService commentService)
  : IQueryHandler<GetFeedbackQuery, Result<List<FeedbackDto>>>

{
  public async Task<Result<List<FeedbackDto>>> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
  {
    var spec = new FeedbackByIdSpec(request.id);

    var list = await repository.ListAsync(cancellationToken);


    if (list == null) return Result.NotFound("Feedback not found");

    var commentDtos = new List<CommentDto>();

    foreach (var feedback in list)
    {
      foreach (var comment in feedback.Comments)
      {
        var dto = await commentService.CreateCommentDtoAsync(comment);
        commentDtos.Add(dto);
      }
    }
    var dtos = new List<FeedbackDto>();
    foreach (var feedback in list)
    {
      dtos.Add(mapper.Map<FeedbackDto>(feedback));
    }
    return Result.Success(dtos);
  }
}
