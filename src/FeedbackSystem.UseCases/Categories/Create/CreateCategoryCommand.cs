using System.Windows.Input;
using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.UseCases.Categories.Create;

public record CreateCategoryCommand(string NewName) : ICommand<Result<int>>;
