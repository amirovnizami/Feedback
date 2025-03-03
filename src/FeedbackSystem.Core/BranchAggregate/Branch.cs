using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.Core.BranchAggregaet.Specifications
{
  public class Branch : EntityBase, IAggregateRoot
  {
    public string Name { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; set; } = null!;

    public Branch(string name, int categoryId) : base()
    {
      Name = Guard.Against.NullOrEmpty(name, nameof(name));
      CategoryId = categoryId;
    }

    public void UpdateName(string newName)
    {
      Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
    }
  }
}
