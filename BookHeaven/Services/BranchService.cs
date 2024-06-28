using BookHeaven.Models;
using BookHeaven.Repositories.Interfaces;
using BookHeaven.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookHeaven.Services
{
    public class BranchService : IBranchService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;


        public BranchService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public async Task AddBranchAsync(Branch branch)
        {
            await _repositoryWrapper.BranchRepository.AddAsync(branch);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task DeleteBranchAsync(Branch branch)
        {
            await _repositoryWrapper.BranchRepository.DeleteAsync(branch);
            await _repositoryWrapper.SaveAsync();
        }

        public async Task<List<Branch>> GetBranches()
        {
            return await _repositoryWrapper.BranchRepository.FindAll().ToListAsync();
        }

      
        public async Task<Branch?> GetBranchByIdAsync(int id)
        {
            return await _repositoryWrapper.BranchRepository.FindByCondition(b => b.BranchId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateBranchAsync(Branch branch)
        {
            await _repositoryWrapper.BranchRepository.UpdateAsync(branch);
            await _repositoryWrapper.SaveAsync();
        }



    }
}
