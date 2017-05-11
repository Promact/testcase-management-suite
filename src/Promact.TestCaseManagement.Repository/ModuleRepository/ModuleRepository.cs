using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promact.TestCaseManagement.Repository.ModuleRepository
{
    public class ModuleRepository : IModuleRepository
    {
        #region Private Member(s)

        readonly TestCaseManagementDbContext _dbContext;

        #endregion

        #region Constructor

        public ModuleRepository(TestCaseManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Method(s)


        public async Task<List<Module>> GetModulesAsync(int projectId)
        {
            return await _dbContext.Module.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public async Task<Module> AddModuleAsync(Module module)
        {
            await _dbContext.Module.AddAsync(module);
            await _dbContext.SaveChangesAsync();
            return module;
        }

        public async Task<Module> UpdateModuleAsync(Module module)
        {
            _dbContext.Module.Update(module);
            await _dbContext.SaveChangesAsync();
            return module;
        }

        public async Task DeleteModuleAsync(Module module)
        {
            module.IsDeleted = true;
            _dbContext.Module.Update(module);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Module> GetModuleAsync(int projectId, int moduleId)
        {
            return await _dbContext.Module.SingleAsync(x => x.ProjectId == projectId && x.Id == moduleId);
        }

        #endregion
    }
}
