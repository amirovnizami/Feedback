using FeedbackSystem.UseCases.Branches.List;
using FeedbackSystem.UseCases.Categories;
using FeedbackSystem.Web.Categories;
using FeedbackSystem.Web.Categories.List;

namespace FeedbackSystem.Web.Branches;

public class ListCategory(IMediator _mediator) : Endpoint<CategoryListRequest, CategoriesListResponse>
{
  public override void Configure()
  {
    Get(CategoryListRequest.Route);
  }

  public override async Task HandleAsync(CategoryListRequest request, CancellationToken cancellationToken)
  {
    Result<List<CategoryDto>> result =
      await _mediator.Send(new ListCategoryQuery(request.Id, request.Name, null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new CategoriesListResponse
      {
        Categories = result.Value.Select(b => new CategoryRecord(b.Id, b.Name)).ToList()
      };
    }
  }
}
