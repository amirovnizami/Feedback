using FeedbackSystem.UseCases.Branches.Get;

namespace FeedbackSystem.Web.Branches;

public class GetById(IMediator _mediator)
  : Endpoint<GetBranchByIdRequest, BranchRecord>
{
  public override void Configure()
  {
    Get(GetBranchByIdRequest.Route);
  }

  public override async Task HandleAsync(GetBranchByIdRequest request,
    CancellationToken cancellationToken)
  {
    var query = new GetBranchQuery(request.BranchId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new BranchRecord(result.Value.Id, result.Value.Name, result.Value.CategoryId);
    }
  }
}
