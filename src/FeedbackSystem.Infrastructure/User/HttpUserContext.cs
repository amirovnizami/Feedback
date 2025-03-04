using System.Security.Claims;
using FeedbackSystem.Core.UsersAggregate;
using FeedbackSystem.UseCases.Security;
using Microsoft.AspNetCore.Http;

namespace FeedbackSystem.Infrastructure.User;

public class HttpUserContext : IUserContext
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly int? _userId;
  private readonly string? _username;
  private readonly string? _email;
  private readonly UserRole? _role;

  public int? UserId { get; set; }
  public string? Username => _username;
  public string? Email => _email;
  public UserRole? Role => _role;

  public HttpUserContext(IHttpContextAccessor httpContextAccessor)
  {
    _httpContextAccessor = httpContextAccessor;
    var user = httpContextAccessor.HttpContext?.User;

    if (user != null)
    {
      var idClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
      var nameClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
      var emailClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
      var roleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

      _userId = int.TryParse(idClaim, out int userId) ? userId : (int?)null;
      _username = nameClaim;
      _email = emailClaim;
      _role = Enum.TryParse<UserRole>(roleClaim, out var role) ? role : null;
    }
  }

  public int MustGetUserId()
  {
    return _userId ?? throw new Exception("User has to Login.");
  }

  public string MustGetUserName()
  {
    return _username ?? throw new Exception("Username is missing.");
  }

  public string MustGetEmail()
  {
    return _email ?? throw new Exception("Email is missing.");
  }

  public UserRole MustGetUserRole()
  {
    return _role ?? UserRole.User;
  }
}
