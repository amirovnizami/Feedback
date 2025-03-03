
using Microsoft.AspNetCore.Http;

namespace FeedbackSystem.Core.Interfaces;

public interface IManageFileService
{
  Task<string> UploadFile(IFormFile file);
  Task<(byte[],string,string)> DownloadFile(string fileName);
}
