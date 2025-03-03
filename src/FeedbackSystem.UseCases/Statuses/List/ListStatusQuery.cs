namespace FeedbackSystem.UseCases.Statuses.List;

public record ListStatusQuery(int? id, string? name, int? Skip, int? Take) : IQuery<Result<List<StatusDto>>>
{
}
