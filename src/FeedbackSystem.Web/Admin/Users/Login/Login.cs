using Ardalis.Result.AspNetCore;
using FeedbackSystem.UseCases.Users.Login;

namespace FeedbackSystem.Web.Users.Login;

public class Login(IMediator _mediator) : Endpoint<LoginRequest, LoginResponse>
{
  public override void Configure()
  {
    Post(LoginRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new LoginRequest() { Email = "admin@admin.com", Password = "123456" };
    });
  }

  public override async Task HandleAsync(LoginRequest request, CancellationToken ct)
  {
    var result = await _mediator.Send(new LoginUserCommand(request.Email, request.Password), ct);

    if (result.IsSuccess)
    {
      Response = new LoginResponse(result.Value);
      return;
    }
    
    await SendResultAsync(result.ToMinimalApiResult());
  }
}
