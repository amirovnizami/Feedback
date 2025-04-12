using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FeedbackSystem.Core.UsersAggregate;

namespace FeedbackSystem.Core.CommentAggregate;

public class Comment : EntityBase, IAggregateRoot
{
  public Comment(string text, int feedbackId, bool isAdmin, string? fileName)
  {
    Text = text;
    FeedbackId = feedbackId;
    IsAdmin = isAdmin;
    FileName = fileName;
  }
  public Comment(string text, int feedbackId, bool isAdmin)
  {
    Text = text;
    FeedbackId = feedbackId;
    IsAdmin = isAdmin;
  }

  public string Text { get; set; }

  public DateTime CreDateTime { get; set; } = DateTime.Now;

  [ForeignKey("FeedbackId")] public int FeedbackId { get; set; }
  public bool IsAdmin { get; set; }
  public string? FileName { get; set; }
  [JsonIgnore] public Feedback Feedback { get; set; } = null!;
}
