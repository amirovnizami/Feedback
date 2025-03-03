using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackSystem.Core.CommentAggregate;
using Microsoft.AspNetCore.Http;

namespace FeedbackSystem.UseCases.Feedbacks.Create;

public record CreateFeedbackCommand(
  string LoginId,
  string FirstName,
  string LastName,
  string Email,
  int BranchId,
  string Comment,
  string FileName) : ICommand<Result<int>>
{
}
