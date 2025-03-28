using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.UseCases.Comments;

namespace FeedbackSystem.UseCases.Feedbacks.Get;

using Microsoft.AspNetCore.Http;
using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;
using FeedbackSystem.UseCases.Security;

public class CommentService
{
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IRepository<Feedback> _feedbackRepository;
  private readonly IUserContext _userContext;

  public CommentService(
    IHttpContextAccessor httpContextAccessor, 
    IRepository<Feedback> feedbackRepository, 
    IUserContext userContext)
  {
    _httpContextAccessor = httpContextAccessor;
    _feedbackRepository = feedbackRepository;
    _userContext = userContext;
  }

  public async Task<CommentDto> CreateCommentDtoAsync(Comment comment)
  {
    bool isAdmin = _httpContextAccessor.HttpContext?.User?.IsInRole("Admin") ?? false;

    string username;
    string email;

    if (isAdmin)
    {
      username = _userContext.MustGetUserName();
      email = _userContext.MustGetEmail();
    }
    else
    {
      var spec = new FeedbackByIdSpec(comment.FeedbackId);
      var feedback = await _feedbackRepository.FirstOrDefaultAsync(spec);
            
      username = string.IsNullOrEmpty(feedback?.FirstName) ? "Anonymous" : feedback.FirstName;
      email = string.IsNullOrEmpty(feedback?.Email) ? "unknown@example.com" : feedback.Email;
    }

    return new CommentDto(comment.Id, comment.Text, username, email);
  }
}
