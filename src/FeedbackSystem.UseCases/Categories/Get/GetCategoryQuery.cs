namespace FeedbackSystem.UseCases.Categories.Get;

public record GetCategoryQuery(int CategoryId) : IQuery<Result<CategoryDto>>;
