namespace FeedbackSystem.Web.Users.Login;

public class LoginResponse(string token)
{
  public string Token { get; set; } = token;
}
