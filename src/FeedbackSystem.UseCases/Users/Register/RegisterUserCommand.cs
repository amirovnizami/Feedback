using System.Windows.Input;

namespace FeedbackSystem.UseCases.Users.Register;

public record RegisterUserCommand(string firstName, string lastName, string email, string password, int role)
  : ICommand<Result<int>>
{
}
