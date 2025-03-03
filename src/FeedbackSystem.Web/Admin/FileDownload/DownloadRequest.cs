namespace FeedbackSystem.Web.Admin.FileDownload;

public class DownloadRequest
{
  public const string Route = "Admin/Download";
  public required string FileName { get; set; }
}
