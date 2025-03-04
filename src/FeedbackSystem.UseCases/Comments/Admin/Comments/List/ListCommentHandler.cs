using AutoMapper;
using FeedbackSystem.Core.CommentAggregate.Specification;

namespace FeedbackSystem.UseCases.Comments.Admin.Comments.List;

public class ListCommentHandler(IListCommentQueryService _query, IMapper mapper)
  : IQueryHandler<ListCommentQuery, Result<List<CommentDto>>>
{
  public async Task<Result<List<CommentDto>>> Handle(ListCommentQuery request, CancellationToken cancellationToken)
  {
    var specification = new CommentByLoginId(request.loginId);
    var result = await _query.ListAsync(specification);
    if (result.Count == 0)
    {
      return Result.NotFound("Comments not found");
    }

    return Result.Success(mapper.Map<List<CommentDto>>(result));
  }
}
