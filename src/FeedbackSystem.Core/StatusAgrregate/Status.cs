
namespace FeedbackSystem.Core.StatusAgrregate;

public class Status : EntityBase, IAggregateRoot
{
  public string StatusName { get; set; } = null!;

  public Status(int id, string statusName)
  {
    Id = id;
    StatusName = statusName;
  }
  public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
