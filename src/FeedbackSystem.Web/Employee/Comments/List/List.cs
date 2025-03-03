using FeedbackSystem.UseCases.Comments;
using FeedbackSystem.UseCases.Comments.Employee.Comments.List;
using FeedbackSystem.Web.Comments.List;
using FeedbackSystem.Web.Employee.Comments.List;

public class ListComment(IMediator _mediator) : Endpoint<CommentListRequest, CommentsListResponse>
{
  public override void Configure()
  {
    Get(CommentListRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(CommentListRequest request, CancellationToken cancellationToken)
  {
    Result<List<CommentDto>> result =
      await _mediator.Send(new ListEmployeeCommentQuery(request.loginId, null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CommentsListResponse
      {
        Comments = result.Value.Select(b => new CommentRecord(b.Id, b.Text)).ToList()
      };
    }
  }
}
