using System.Windows.Input;

namespace FeedbackSystem.UseCases.Categories.Delete;

public record DeleteCategoryCommand(int categoryId) : ICommand<Result>;
