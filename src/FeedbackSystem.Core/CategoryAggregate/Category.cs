using System.ComponentModel.DataAnnotations;
using FeedbackSystem.Core.BranchAggregaet.Specifications;

namespace FeedbackSystem.Core.CategoryAggregate;

public class Category : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }

  public IEnumerable<Branch> Branches { get; set; } = new List<Branch>();

  public Category(string name)
  {
    Name = Guard.Against.NullOrEmpty(name, nameof(name));
  }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
