using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Services.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace FeedbackSystem.Core.Services;

public class ManageFileService(IConfiguration configuration) : IManageFileService
{
  public async Task<string> UploadFile(IFormFile iFormFile)
  {
    string fileName = "";
    try
    {
      string fileExtension = Path.GetExtension(iFormFile.FileName).ToLower();
      var allowedExtensions = configuration.GetSection("FileUpload:AllowedExtensions").Get<List<string>>() ?? new List<string>();
      if (!allowedExtensions.Contains(fileExtension))
      {
        throw new Exception($"FileExtension {fileExtension} is not supported.");
      }
      FileInfo fileInfo = new FileInfo(iFormFile.FileName);
      fileName = iFormFile.FileName + "_" + DateTime.Now.Ticks.ToString() + fileInfo.Extension;
      // var getFilePath = configuration.GetSection("FileUpload:FilePath").Value;
      var _GetFilePath = Common.GetFilePath(fileName);
      await using var fileStream = new FileStream(_GetFilePath, FileMode.Create);
      await iFormFile.CopyToAsync(fileStream);

      return fileName;
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }

  public async Task<(byte[], string, string)> DownloadFile(string fileName)
  {
    try
    {
      var getFilePath = Common.GetFilePath(fileName);
      var provider = new FileExtensionContentTypeProvider();
      if (!provider.TryGetContentType(getFilePath, out var contentType))
      {
        if (getFilePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
        {
          contentType = "image/png";
        }
        else
        {
          contentType = "application/octet-stream"; // Default content type
        }
      }

      var readAllBytesAsync = await File.ReadAllBytesAsync(getFilePath);
      return (readAllBytesAsync, contentType, Path.GetFileName(getFilePath));
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}
