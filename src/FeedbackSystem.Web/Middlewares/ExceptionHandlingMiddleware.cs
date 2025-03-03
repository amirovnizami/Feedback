using Newtonsoft.Json;

public class UnauthorizedMiddleware
{
  private readonly RequestDelegate _next;

  public UnauthorizedMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    await _next(context);

    if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
    {
      context.Response.ContentType = "application/json";
      var response = new { Code = 401, Message = "Unauthorized: Please provide valid authentication credentials." };
      await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
  }
}
