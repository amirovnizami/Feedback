namespace FeedbackSystem.Core.UsersAggregate.Specifications;

public class UserSpecification : Specification<User>
{
  public UserSpecification(string? firstName, string email)
  {
    var searchText = firstName ?? string.Empty;

    Query.Where(user => user.FirstName == searchText || user.Email == email);
  }
}
