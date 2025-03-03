namespace FeedbackSystem.UseCases.Security;

public interface IUserContext
{
  public int? UserId { get; set; }
  public int MustGetUserId();
}
