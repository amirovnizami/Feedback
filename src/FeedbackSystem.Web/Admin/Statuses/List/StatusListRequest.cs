namespace FeedbackSystem.Web.Statuses.List;

public class StatusListRequest
{
  public const string Route = "Admin/Statuses";

  public int? Id { get; set; } = null;
  public string? Name { get; set; } = null;
}
