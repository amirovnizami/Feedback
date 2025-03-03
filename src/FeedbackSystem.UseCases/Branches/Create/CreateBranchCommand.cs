using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.UseCases.Contributors.Create;

public record CreateBranchCommand(string Name, int CategoryId) : Ardalis.SharedKernel.ICommand<Result<int>>;
