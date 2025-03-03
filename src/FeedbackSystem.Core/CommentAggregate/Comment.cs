using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FeedbackSystem.Core.UsersAggregate;

namespace FeedbackSystem.Core.CommentAggregate;

public class Comment : EntityBase, IAggregateRoot
{
  public Comment(string text, int feedbackId, int? userId, string? fileName)
  {
    Text = text;
    FeedbackId = feedbackId;
    UserId = userId;
    FileName = fileName;
  }
  public Comment(string text, int feedbackId, int? userId)
  {
    Text = text;
    FeedbackId = feedbackId;
    UserId = userId;
  }

  public string Text { get; set; }

  public DateTime CreDateTime { get; set; } = DateTime.Now;

  [ForeignKey("FeedbackId")] public int FeedbackId { get; set; }
  public int? UserId { get; set; }

  public string? FileName { get; set; }
  [JsonIgnore] public Feedback Feedback { get; set; } = null!;
  public User? User { get; set; }
}
