using FeedbackSystem.Core.BranchAggregaet.Specifications;

// using FeedbackSystem.Core.BranchAggregate;

namespace FeedbackSystem.Infrastructure.Data;

public static class SeedData
{
  public static async Task InitializeAsync(AppDbContext dbContext)
  {
    // if (await dbContext.Contributors.AnyAsync() && await dbContext.Branches.AnyAsync()) return; // DB has been seeded

    await PopulateTestDataAsync(dbContext);
  }

  public static async Task PopulateTestDataAsync(AppDbContext dbContext)
  {
    if (dbContext.Branches.Any()) return;
    await dbContext.SaveChangesAsync();
  }
}
