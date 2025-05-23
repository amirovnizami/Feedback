﻿namespace FeedbackSystem.UseCases.Comments;

public class CommentDto
{
  public int Id { get; set; }
  public string Text { get; set; }
  public bool IsAdmin { get; set; }
  public string? Username { get; set; }
  public string? Email { get; set; }

  
  public CommentDto(int id, string text,bool isAdmin)
  {
    Id = id;
    Text = text;
    IsAdmin = isAdmin;
  }
  public CommentDto(int id, string text, string? username, string? email)
  {
    Id = id;
    Text = text;
    Username = username;
    Email = email;
  }
}
