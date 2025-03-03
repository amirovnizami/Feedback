using FeedbackSystem.UseCases.Statuses;
using FeedbackSystem.UseCases.Statuses.List;

namespace FeedbackSystem.Web.Statuses.List;

public class List(IMediator _mediator) : Endpoint<StatusListRequest, StatusListResponse>
{
  public override void Configure()
  {
    Get(StatusListRequest.Route);
  }

  public override async Task HandleAsync(StatusListRequest req, CancellationToken ct)
  {
    Result<List<StatusDto>> result = await _mediator.Send(new ListStatusQuery(req.Id, req.Name, null, null), ct);

    if (result.IsSuccess)
    {
      Response = new StatusListResponse
      {
        Statuses = result.Value.Select(s => new StatusRecord(s.id, s.StatusName)).ToList()
      };
    }
  }
}
