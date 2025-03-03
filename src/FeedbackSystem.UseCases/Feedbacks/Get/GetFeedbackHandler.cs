using AutoMapper;
using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.UseCases.Comments;

namespace FeedbackSystem.UseCases.Feedbacks.Get;

public class GetFeedbackHandler(IReadRepository<Feedback> repository, IMapper mapper) :
  IQueryHandler<GetFeedbackQuery, Result<FeedbackDto>>
{
  public async Task<Result<FeedbackDto>> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
  {
    var spec = new FeedbackByIdSpec(request.id);
    var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (entity == null) return Result.NotFound("Feedback not found");

    var commenList = mapper.Map<IEnumerable<CommentDto>>(entity.Comments);
    return new FeedbackDto(entity.LoginId, entity.FirstName, entity.LastName, entity.Email, entity.BranchId,
      commenList);
  }
}
