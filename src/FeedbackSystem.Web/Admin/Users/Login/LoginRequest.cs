using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Web.Users.Login;

public class LoginRequest
{
  public const string Route = "Admin/Users/Login";
  public required string Email { get; set; }
  public required string Password { get; set; }
}
