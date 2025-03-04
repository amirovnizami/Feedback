using Ardalis.Result.AspNetCore;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.UseCases.Comments.Admin.Comments.Create;

namespace FeedbackSystem.Web.Admin.Comments.Create;

public class Create(IMediator mediator,IManageFileService manageFileService) : Endpoint<CreateCommentRequest, CreateCommentResponse>
{
  public override void Configure()
  {
    Post(CreateCommentRequest.Route);
    AllowFileUploads();
    Summary(s =>
    {
      s.ExampleRequest = new CreateCommentRequest() { feedbackId = 1, Comment = "Message" };
    });
  }

  public override async Task HandleAsync(CreateCommentRequest request, CancellationToken ct)
  {
    string? fileName = null;
    if (request.UploadFile != null)
    {
      fileName = await manageFileService.UploadFile(request.UploadFile);
      
    }

    var result = await mediator.Send(new CreateAdminCommentCommand(request.feedbackId, request.Comment,fileName), ct);
    if (result.IsSuccess)
    {
      Response = new CreateCommentResponse(result.Value, request.Comment);
    }
    // await SendResultAsync(result.ToMinimalApiResult());
  }
}
