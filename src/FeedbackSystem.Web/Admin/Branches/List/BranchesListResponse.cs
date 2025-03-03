using FeedbackSystem.Web.Branches;

namespace FeedbackSystem.Web.Admin.Branches;

public class BranchListResponse
{
  public List<BranchRecord> Branches { get; set; } = [];
}
