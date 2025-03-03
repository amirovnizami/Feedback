namespace FeedbackSystem.Core.FeedbackAgrregate.Specifications;

public class FeedbackByLoginId : Specification<Feedback>
{
  public FeedbackByLoginId(string id)
  {
    Query.Where(f => f.LoginId == id);
  }
}
