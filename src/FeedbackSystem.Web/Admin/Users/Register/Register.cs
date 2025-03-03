using Ardalis.Result.AspNetCore;
using FeedbackSystem.UseCases.Users.Register;

namespace FeedbackSystem.Web.Users.Register;

public class Register(IMediator _mediator) : Endpoint<RegisterRequest, RegisterResponse>
{
  public override void Configure()
  {
    Post(RegisterRequest.Route);
    Summary(s =>
    {
      s.ExampleRequest = new RegisterRequest()
      {
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@gmail.com",
        Password = "123456",
        Role = 1
      };
    });
  }

  public override async Task HandleAsync(RegisterRequest request, CancellationToken ct)
  {
    var result =
      await _mediator.Send(
        new RegisterUserCommand(request.FirstName, request.LastName, request.Email, request.Password, request.Role),
        ct);

    if (result.IsSuccess)
    {
      Response = new RegisterResponse(result.Value, request.FirstName, request.LastName, request.Email,
        request.Password, request.Role);
      return;
    }

    await SendResultAsync(result.ToMinimalApiResult());
  }
}
