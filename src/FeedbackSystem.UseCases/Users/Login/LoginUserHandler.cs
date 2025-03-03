using FeedbackSystem.Core.Interfaces;
using Org.BouncyCastle.Crypto.Generators;

namespace FeedbackSystem.UseCases.Users.Login;

using FeedbackSystem.Core.UsersAggregate;
using FeedbackSystem.Core.UsersAggregate.Specifications;

public class LoginUserHandler(IRepository<User> _repository, ITokenService tokenService)
  : ICommandHandler<LoginUserCommand, Result<string>>
{
  private readonly ITokenService _tokenService = tokenService;

  public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
  {
    var user = await _repository.FirstOrDefaultAsync(
      new UserSpecification(null, request.email), cancellationToken);

    if (user is null)
    {
      return Result.Error("Invalid email or password");
    }

    bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.password, user.PasswordHash);

    if (!isPasswordValid)
    {
      return Result.Error("Invalid email or password");
    }

    var token = _tokenService.GenerateJWT(user);

    return Result.Success(token);
  }
}
