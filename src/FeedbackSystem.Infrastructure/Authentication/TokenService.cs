using FeedbackSystem.Core.Interfaces;

namespace FeedbackSystem.Infrastructure.Authentication;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class TokenService(IConfiguration configuration) : ITokenService
{
  private readonly IConfiguration _configuration = configuration;

  public string GenerateJWT(Core.UsersAggregate.User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"] ?? "");

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new[]
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), new Claim(ClaimTypes.Name, user.FirstName ?? ""),
      }),
      Expires = DateTime.UtcNow.AddDays(1),
      Issuer = _configuration["JwtSettings:Issuer"],
      Audience = _configuration["JwtSettings:Audience"],
      SigningCredentials =
        new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
}
