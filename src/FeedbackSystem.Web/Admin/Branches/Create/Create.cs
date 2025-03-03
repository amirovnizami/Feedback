using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using FeedbackSystem.UseCases.Contributors.Create;
using FeedbackSystem.Web.Branchs.Create;

namespace FeedbackSystem.Web.Branches
{
  [Authorize]
  public class Create(IMediator _mediator) : Endpoint<CreateBranchRequest, CreateBranchResponse>
  {
    public override void Configure()
    {
      Post(CreateBranchRequest.Route);
      Summary(s =>
      {
        s.ExampleRequest = new CreateBranchRequest { Name = "Branch Name", CategoryId = 1 };
      });
    }

    public override async Task HandleAsync(
      CreateBranchRequest request,
      CancellationToken cancellationToken)
    {
      var result = await _mediator.Send(new CreateBranchCommand(request.Name!, request.CategoryId), cancellationToken);

      if (result.IsSuccess)
      {
        Response = new CreateBranchResponse(result.Value, request.Name!);
        return;
      }

      await SendResultAsync(result.ToMinimalApiResult());
    }
  }
}
