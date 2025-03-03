using FeedbackSystem.UseCases.Branches.Get;
using FeedbackSystem.UseCases.Branches.Update;

namespace FeedbackSystem.Web.Branches.Update;

public class UpdateBranch(IMediator _mediator)
  : Endpoint<UpdateBranchRequest, UpdateBranchResponse>
{
  public override void Configure()
  {
    Put(UpdateBranchRequest.Route);
  }

  public override async Task HandleAsync(UpdateBranchRequest request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateBranchCommand(request.BranchId, request.Name), cancellationToken);
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetBranchQuery(request.BranchId);
    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateBranchResponse(new BranchRecord(dto.Id, dto.Name, dto.CategoryId));
      return;
    }
  }
}
