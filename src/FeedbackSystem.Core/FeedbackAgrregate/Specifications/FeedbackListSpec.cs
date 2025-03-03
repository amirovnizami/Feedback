using Ardalis.Specification;

namespace FeedbackSystem.Core.FeedbackAgrregate.Specifications;

public sealed class FeedbackListSpec : Specification<Feedback>
{
  public FeedbackListSpec(string? searchText, int? branchId, int? statusId)
  {
    if (!string.IsNullOrWhiteSpace(searchText))
    {
      Query.Include(f => f.Comments);
      Query.Where(feedback =>
        feedback.FirstName!.ToLower().Contains(searchText.ToLower()) ||
        feedback.LastName!.ToLower().Contains(searchText.ToLower()) ||
        feedback.Email!.ToLower().Contains(searchText.ToLower())
      );
    }

    if (branchId.HasValue)
    {
      Query.Where(feedback => feedback.BranchId == branchId.Value);
    }
  }
}
