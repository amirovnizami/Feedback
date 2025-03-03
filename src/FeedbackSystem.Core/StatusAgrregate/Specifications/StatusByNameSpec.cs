namespace FeedbackSystem.Core.StatusAgrregate.Specifications;

public class StatusByNameSpec : Specification<Status>
{
  public StatusByNameSpec(string name)
  {
    Query.Where(s => s.StatusName == name);
  }
}
