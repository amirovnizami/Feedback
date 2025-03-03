using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result.AspNetCore;
using FeedbackSystem.UseCases.Categories.Create;

namespace FeedbackSystem.Web.Categories.Create;

public class Create(IMediator _mediator) : Endpoint<CreateCategoryRequest, CreateCategoryResponse>
{
  public override void Configure()
  {
    Post(CreateCategoryRequest.Route);
    Summary(s =>
    {
      s.ExampleRequest = new CreateCategoryRequest { Name = "Category Name" };
    });
  }

  public override async Task HandleAsync(
    CreateCategoryRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateCategoryCommand(request.Name!), cancellationToken);
    if (result.IsSuccess)
    {
      if (result.Value == 0)
      {
        return;
      }

      Response = new CreateCategoryResponse(result.Value, request.Name!);
      return;
    }

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
