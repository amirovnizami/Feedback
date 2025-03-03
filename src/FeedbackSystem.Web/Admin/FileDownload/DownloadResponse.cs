using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.Web.Admin.FileDownload
{
  public class DownloadResponse(FileContentResult fileContentResult)
  {
    public FileContentResult File { get; set; } = fileContentResult;
  }
}
