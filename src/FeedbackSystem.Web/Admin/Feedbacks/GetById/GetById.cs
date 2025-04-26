using FeedbackSystem.UseCases.Feedbacks.Get;

public class GetById(IMediator _mediator)
  : Endpoint<GetFeedbackByIdRequest, List<FeedbackRecord>>
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
      Response = new List<FeedbackRecord>();
  
      foreach (var feedback in result.Value)
      {
        var record = new FeedbackRecord(
          feedback.loginId,
          feedback.firstName,
          feedback.lastName,
          feedback.email,
          feedback.branchId,
          feedback.statusId,
          feedback.createdDate,
          feedback.comments
        );
    
        Response.Add(record);
      }
    }
  }
}
