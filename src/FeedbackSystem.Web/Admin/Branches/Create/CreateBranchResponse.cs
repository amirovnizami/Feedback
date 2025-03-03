namespace FeedbackSystem.Web.Branchs.Create;

public class CreateBranchResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
  public DateTime CreatedDate { get; set; }
}
