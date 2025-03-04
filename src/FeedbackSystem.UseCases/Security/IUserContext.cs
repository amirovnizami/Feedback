using FeedbackSystem.Core.UsersAggregate;

namespace FeedbackSystem.UseCases.Security;

public interface IUserContext
{
  int? UserId { get; set; }
  string? Username { get; }
  string? Email { get; }
  UserRole? Role { get;  }

  
  int MustGetUserId();
  string MustGetUserName();
  string MustGetEmail();
  UserRole MustGetUserRole();
}
