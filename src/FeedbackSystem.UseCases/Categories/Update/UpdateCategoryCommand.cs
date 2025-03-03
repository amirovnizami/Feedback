namespace FeedbackSystem.UseCases.Categories.Update;

public record UpdateCategoryCommand(int id, string? NewName) : ICommand<Result<CategoryDto>>
{
}
