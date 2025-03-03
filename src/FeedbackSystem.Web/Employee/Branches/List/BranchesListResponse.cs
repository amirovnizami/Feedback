using FeedbackSystem.Web.Branches;

namespace FeedbackSystem.Web.Branches;

public class BranchListResponse
{
  public List<BranchRecord> Branches { get; set; } = [];
}
