namespace FeedbackSystem.Web.Admin.Branches.Delete;

public record DeleteBranchRequest
{
  public const string Route = "Admin/Branches/{BranchId:int}";
  public static string BuildRoute(int branchId) => Route.Replace("{BranchId:int}", branchId.ToString());

  public int BranchId { get; set; }
}
