using FeedbackSystem.UseCases.Categories.Get;

namespace FeedbackSystem.Web.Categories.GetById;

public class GetById(IMediator _mediator)
  : Endpoint<GetCategoryByIdRequest, CategoryRecord>
{
  public override void Configure()
  {
    Get(GetCategoryByIdRequest.Route);
  }

  public override async Task HandleAsync(GetCategoryByIdRequest request,
    CancellationToken cancellationToken)
  {
    var query = new GetCategoryQuery(request.CategoryId);

    var result = await _mediator.Send(query, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new CategoryRecord(result.Value.Id, result.Value.Name);
    }
  }
}
