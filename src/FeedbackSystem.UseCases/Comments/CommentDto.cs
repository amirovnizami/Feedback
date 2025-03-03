namespace FeedbackSystem.UseCases.Comments;

public class CommentDto
{
  public int Id { get; set; }
  public string Text { get; set; } = null!;
  public string Username { get; set; } = null!;
  public string Email { get; set; } = null!;

  public CommentDto(int id, string text, string username, string email)
  {
    Id = id;
    Text = text;
    Username = username;
    Email = email;
  }
  public CommentDto() {}


}
