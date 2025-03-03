namespace FeedbackSystem.Core.Interfaces;

public interface IDeleteBranchService
{
  public Task<Result> DeleteBranch(int branchId);
}
