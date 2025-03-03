namespace FeedbackSystem.Web.Employee.FileDownload;

public class DownloadRequest
{
  public const string Route = "Employee/Download";
  public required string FileName { get; set; }
}
