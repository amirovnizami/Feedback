using FeedbackSystem.Core.UsersAggregate;

namespace FeedbackSystem.Core.Interfaces;

public interface ITokenService
{
  string GenerateJWT(User user);
}
