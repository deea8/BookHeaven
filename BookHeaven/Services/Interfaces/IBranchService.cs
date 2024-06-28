using BookHeaven.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookHeaven.Services.Interfaces
{
    public interface IBranchService
    {
        Task<List<Branch>> GetBranches();
        Task<Branch?> GetBranchByIdAsync(int id);
        Task AddBranchAsync(Branch branch);
        Task UpdateBranchAsync(Branch branch);
        Task DeleteBranchAsync(Branch branch);
    }
}
