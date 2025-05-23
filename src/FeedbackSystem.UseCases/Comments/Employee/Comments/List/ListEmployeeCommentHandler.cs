﻿using AutoMapper;
using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.CommentAggregate.Specification;
using FeedbackSystem.UseCases.Comments.Admin.Comments.List;

namespace FeedbackSystem.UseCases.Comments.Employee.Comments.List;

public class ListEmployeeCommentHandler(IListCommentQueryService _query, IMapper mapper)
  : IQueryHandler<ListEmployeeCommentQuery, Result<List<CommentDto>>>
{
  public async Task<Result<List<CommentDto>>> Handle(ListEmployeeCommentQuery request, CancellationToken cancellationToken)
  {
    var specification = new CommentByLoginId(request.loginId);
    var result = await _query.ListAsync(specification);
    if (result == null || result.Count == 0)
    {
      return Result.Error("Login failed.");
    }
    return Result.Success(mapper.Map<List<CommentDto>>(result));
  }
}
