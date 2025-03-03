using Microsoft.Extensions.Configuration;

namespace FeedbackSystem.Core.Services.Helper;

public static class Common
{
  private static IConfiguration _configuration = null!;

  public static void Initialize(IConfiguration configuration)
  {
    _configuration = configuration;
  }
  public static string GetCurrentDirectory()
  {
    var result = Directory.GetCurrentDirectory();
    return result;
  }
  public static string GetStaticContentDirectory()
  {
    var result = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\StaticContent\\");
    if (!Directory.Exists(result))
    {
      Directory.CreateDirectory(result);
    }
    return result;
  }
  public static string GetFilePath(string fileName)
  {
    var getStaticContentDirectory = _configuration!["FileUpload:FilePath"]; 
    if (string.IsNullOrEmpty(getStaticContentDirectory))
    {
      throw new Exception("FileUpload:FilePath could't be null or empty.");
    }

    var result = Path.Combine(getStaticContentDirectory, fileName);
    return result;
  }
}
