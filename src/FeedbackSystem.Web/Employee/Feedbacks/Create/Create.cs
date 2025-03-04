using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.UseCases.Feedbacks.Create;

namespace FeedbackSystem.Web.Employee.Feedbacks.Create;

public class Create(IMediator mediator, IIdGeneratorService generateService,IManageFileService manageFileService)
  : Endpoint<CreateFeedbackRequest, CreateFeedbackResponse>
{
  public override void Configure()
  {
    Post(CreateFeedbackRequest.Route);
    AllowAnonymous();
    AllowFileUploads();
    Summary(s =>
    {
      s.ExampleRequest = new CreateFeedbackRequest()
      {
        FirstName = "First Name",
        LastName = "Last Name",
        Email = "example@gmail.com",
        BranchId = 1,
        Comment = "Message"
      };
    });
  }

  public override async Task HandleAsync(CreateFeedbackRequest request, CancellationToken ct)
  {

    var loginId = generateService.CustomGenerateId();
    var fileName = await manageFileService.UploadFile(request.UploadFile!);

    var result =
      await mediator.Send(
        new CreateFeedbackCommand(loginId, request.FirstName!, request.LastName!, request.Email!, request.BranchId,
          request.Comment,fileName), ct);

    if (result.IsSuccess)
    {
      Response = new CreateFeedbackResponse(loginId);
    }

    // await SendResultAsync(result.ToMinimalApiResult());
  }
}
