using System.Windows.Input;

namespace FeedbackSystem.UseCases.Users.Login;

public record LoginUserCommand(string email, string password) : ICommand<Result<string>>;
