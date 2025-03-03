using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.UseCases.Branches;

public record BranchDto(int Id, string Name, int? CategoryId);
