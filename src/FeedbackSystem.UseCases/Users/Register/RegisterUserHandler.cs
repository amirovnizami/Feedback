using FeedbackSystem.Core.UsersAggregate;
using FeedbackSystem.Core.UsersAggregate.Specifications;

namespace FeedbackSystem.UseCases.Users.Register;

public class RegisterUserHandler(IRepository<User> _repository) : ICommandHandler<RegisterUserCommand, Result<int>>
{
  public async Task<Result<int>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
  {
    var exisitingUser = await _repository.FirstOrDefaultAsync(
      new UserSpecification(request.firstName, request.email), cancellationToken);
    if (exisitingUser is not null)
    {
      return Result.Error("User already exists");
    }

    if (!Enum.IsDefined(typeof(UserRole), request.role))
    {
      return Result.Error("Invalid role value");
    }

    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.password);

    var userRole = (UserRole)request.role;

    var newUser = new User(request.firstName, request.lastName, request.email, hashedPassword, userRole);

    var createdItem = await _repository.AddAsync(newUser, cancellationToken);

    return Result.Success(createdItem.Id);
  }
}
