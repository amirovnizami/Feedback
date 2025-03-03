using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Web.Users.Register;

public class RegisterRequest
{
  public const string Route = "Admin/Users/Register";
  public required string FirstName { get; set; }
  public required string LastName { get; set; }
  public required string Email { get; set; }
  public required string Password { get; set; }
  public int Role { get; set; }
}
