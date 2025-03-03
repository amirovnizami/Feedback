using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.UseCases.Comments.Employee.Comments.Create;

namespace FeedbackSystem.Web.Employee.Comments.Create;

public class Create(IMediator mediator, IManageFileService manageFileService) : Endpoint<CreateCommentRequest,  CreateCommentResponse>
{
  private readonly IManageFileService _manageFileService = manageFileService;
  
  public override void Configure()
  {
    Post(CreateCommentRequest.Route);
    AllowAnonymous();
    AllowFileUploads();
    Summary(s =>
    {
      s.ExampleRequest = new CreateCommentRequest() { loginId = "XX12345678", Comment = "Message" };
    });
  }

  public override async Task HandleAsync(CreateCommentRequest request, CancellationToken ct)
  {
    var fileName = await _manageFileService.UploadFile(request.File!);
    var result = await mediator.Send(new CreateEmployeeCommentCommand(request.loginId, 1,request.Comment,fileName), ct);
    if (result.IsSuccess)
    {
      Response = new CreateCommentResponse(result.Value, request.Comment);
    }
  }
}
