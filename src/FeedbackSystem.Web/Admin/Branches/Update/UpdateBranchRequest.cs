using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Web.Branches.Update;

public class UpdateBranchRequest
{
  public const string Route = "Admin/Branches/{BranchId:int}";
  public static string BuildRoute(int branchId) => Route.Replace("{BranchId:int}", branchId.ToString());
  [Required] public int BranchId { get; set; }
  [Required] public string? Name { get; set; }
}
