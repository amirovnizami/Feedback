
public class GetFeedbackByIdRequest
{
  public const string Route = "Admin/Feedbacks/{Id:int}";
  public static string BuildRoute(int id) => Route.Replace("{Id:int}", id.ToString());

  public int Id { get; set; }
}
