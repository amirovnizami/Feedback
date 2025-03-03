using FeedbackSystem.UseCases.Categories;

namespace FeedbackSystem.UseCases.Branches.List;

public record ListCategoryQuery(int? id, string? name, int? Skip, int? Take) : IQuery<Result<List<CategoryDto>>>
{
}
