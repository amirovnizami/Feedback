namespace FeedbackSystem.Core.StatusAgrregate.Specifications;

public class StatusListSpec : Specification<Status>
{
  public StatusListSpec(int? id, string? name)
  {
    var searchText = name ?? string.Empty;
    Query.Where(status => status.StatusName.ToLower().Contains(searchText) || status.Id == id);
  }
}
