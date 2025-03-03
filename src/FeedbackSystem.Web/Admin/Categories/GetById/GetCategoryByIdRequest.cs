namespace FeedbackSystem.Web.Categories.GetById;

public class GetCategoryByIdRequest
{
  public const string Route = "Admin/Categories/{CategoryId:int}";
  public static string BuildRoute(int categoryId) => Route.Replace("{CategoryId:int}", categoryId.ToString());

  public int CategoryId { get; set; }
}
