using System;

namespace FeedbackSystem.Web.Categories.Create;

public class CreateCategoryResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
  public DateTime CreateDate { get; set; }
}
