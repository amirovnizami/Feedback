using FeedbackSystem.UseCases.Feedbacks.Get;

public class GetById(IMediator _mediator)
  : Endpoint<GetFeedbackByIdRequest, FeedbackRecord>
{
  public override void Configure()
  {
    Get(GetFeedbackByIdRequest.Route);
  }

  public override async Task HandleAsync(GetFeedbackByIdRequest request,
    CancellationToken cancellationToken)
  {
    var query = new GetFeedbackQuery(request.Id);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new FeedbackRecord(result.Value.loginId, result.Value.firstName, result.Value.lastName,
        result.Value.email, result.Value.branchId, result.Value.comments);
    }
  }
}
