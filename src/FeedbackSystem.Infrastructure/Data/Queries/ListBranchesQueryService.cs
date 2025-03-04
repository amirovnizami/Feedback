using System.Linq;
using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.BranchAggregate.Specifications;
using FeedbackSystem.UseCases.Branches.List;

namespace FeedbackSystem.Infrastructure.Data.Queries
{
  public class ListBranchesQueryService : IListBranchesQueryService
  {
    private readonly AppDbContext _db;

    public ListBranchesQueryService(AppDbContext db)
    {
      _db = db;
    }

    public Task<List<Branch>> ListAsync(BranchListSpec branchListSpec)
    {
      return _db.Branches.ToListAsync(branchListSpec);
    }
  }
}
