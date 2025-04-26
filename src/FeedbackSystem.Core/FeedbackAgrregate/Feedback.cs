using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.StatusAgrregate;
using FeedbackSystem.Core.UsersAggregate;

public class Feedback : EntityBase, IAggregateRoot
{
  public Feedback()
  {
    Comments = new List<Comment>();
  }

  public Feedback(string loginId, string? firstName, string? lastName, string? email, int branchId, Comment comment)
    : this()
  {
    LoginId = loginId;
    FirstName = firstName;
    LastName = lastName;
    Email = email;
    BranchId = branchId;
    AddComment(comment);
  }

  public string LoginId { get; set; } = null!;
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Email { get; set; }
  public int BranchId { get; set; }

  public int? StatusId { get; set; } = 1;
  public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
  [ForeignKey("StatusId")] public Status Status { get; set; } = null!;
  [JsonIgnore] public ICollection<Comment> Comments { get; set; } = new List<Comment>();
  public Branch Branch { get; set; } = null!;


  public void AddComment(Comment comment)
  {
    Comments.Add(comment);
  }

  public void UpdateName(int newBranchId, Comment newComment)
  {
    Comments.Add(newComment);
    BranchId = newBranchId;
  }
}
