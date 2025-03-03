namespace FeedbackSystem.Web.Users.Register;

public class RegisterResponse(int id, string firstName, string lastName, string email, string password, int roleid)
{
  public int Id { get; set; } = id;
  public string FirstName { get; set; } = firstName;
  public string LastName { get; set; } = lastName;
  public string Email { get; set; } = email;
  public string Password { get; set; } = password;
  public int Role { get; set; } = roleid;
  public DateTime CreatedDate { get; set; }
}
