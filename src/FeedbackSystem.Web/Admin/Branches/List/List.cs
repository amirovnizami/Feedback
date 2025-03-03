using Microsoft.AspNetCore.Authorization;
using FeedbackSystem.UseCases.Branches;
using FeedbackSystem.UseCases.Branches.List;
using FeedbackSystem.Web.Branches;

namespace FeedbackSystem.Web.Admin.Branches;

[Authorize]
public class List(IMediator _mediator) : Endpoint<BrancListRequest, BranchListResponse>
{
  public override void Configure()
  {
    Get(BrancListRequest.Route);
  }

  public override async Task HandleAsync(BrancListRequest request, CancellationToken cancellationToken)
  {
    Result<List<BranchDto>> result =
      await _mediator.Send(new ListBranchesQuery(request.Name, request.CategoryId, null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new BranchListResponse
      {
        Branches = result.Value.Select(b => new BranchRecord(b.Id, b.Name, b.CategoryId)).ToList()
      };
    }
  }
}
