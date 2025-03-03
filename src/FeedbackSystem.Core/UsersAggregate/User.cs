using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FeedbackSystem.Core.CommentAggregate;

namespace FeedbackSystem.Core.UsersAggregate;

public class User : EntityBase, IAggregateRoot
{
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string PasswordHash { get; set; } = string.Empty;

  public UserRole Role { get; set; }

  // public ICollection<Comment> comments;

  public User(string firstName, string lastName, string email, string passwordHash, UserRole role)
  {
    FirstName = firstName;
    LastName = lastName;
    Email = email;
    PasswordHash = passwordHash;
    Role = role;
  }
}
