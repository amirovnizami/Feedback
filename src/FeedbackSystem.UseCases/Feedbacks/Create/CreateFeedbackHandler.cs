using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.UseCases.Security;

namespace FeedbackSystem.UseCases.Feedbacks.Create;

public class CreateFeedbackHandler(IRepository<Feedback> repository) :
  ICommandHandler<CreateFeedbackCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
  {
    var newFeedback = new Feedback(request.LoginId, request.FirstName, request.LastName, request.Email,
      request.BranchId, new Comment(request.Comment, 0, false,request.FileName));
    var createdItem = await repository.AddAsync(newFeedback, cancellationToken);
    return Result.Success(createdItem.Id);
  }
}
