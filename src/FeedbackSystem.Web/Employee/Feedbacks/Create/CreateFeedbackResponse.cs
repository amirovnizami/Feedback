using FeedbackSystem.Core.CommentAggregate;

namespace FeedbackSystem.Web.Feedbacks.Create;

public class CreateFeedbackResponse(string loginId)
{
  // public int Id { get; set; } = id;
  public string LoginId { get; set; } = loginId;

  // public string FirstName { get; set; } = firstname;
  // public string LastName { get; set; } = lastname;
  // public string Email { get; set; } = email;
  // public int BranchId { get; set; } = branchId;
  // public string Comment { get; set; } = comment;
  public DateTime CreatedDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
}
