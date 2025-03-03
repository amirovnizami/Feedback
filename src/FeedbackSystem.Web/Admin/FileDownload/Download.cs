using AutoWrapper.Filters;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Services.Helper;

namespace FeedbackSystem.Web.Admin.FileDownload
{
  public class Download(IManageFileService manageFileService) : Endpoint<Employee.FileDownload.DownloadRequest>
  {
    public override void Configure()
    {
      Get(DownloadRequest.Route);
      AllowAnonymous();
    }

    [AutoWrapIgnore(ShouldLogRequestData =false)]
    public override async Task HandleAsync(Employee.FileDownload.DownloadRequest request, CancellationToken ct)
    {
      var fileData = await manageFileService.DownloadFile(request.FileName);
      var contentType = fileData.Item2;
      var fileDownloadName = fileData.Item3;
      
      await using var fileStream = new FileStream(Common.GetFilePath(request.FileName), FileMode.Open, FileAccess.Read, FileShare.Read);
      await SendStreamAsync(
        stream: fileStream,
        fileName: fileDownloadName,
        contentType: contentType,
        cancellation: ct
      );

    }
  }
}
