using System.Security.Claims;
using FeedbackSystem.UseCases.Security;
using Microsoft.AspNetCore.Http;

namespace FeedbackSystem.Infrastructure.User;

public class HttpUserContext : IUserContext
{
  private readonly int? _userId;
  public int? UserId { get; set; }

  public HttpUserContext(IHttpContextAccessor httpContextAccessor)
  {
    var id = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
      ?.Value;
    bool isOk = int.TryParse(id, out int userId);
    _userId = isOk ? userId : null;
  }

  public int MustGetUserId()
  {
    if (_userId == null)
    {
      throw new Exception("User has to Login.");
    }

    return _userId.Value;
  }
}
