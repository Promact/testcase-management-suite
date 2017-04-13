using Microsoft.EntityFrameworkCore;
using Promact.TestCaseManagement.DomainModel.DataContext;
using Promact.TestCaseManagement.DomainModel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Promact.TestCaseManagement.Repository.ScenarioRepository
{
    public class ScenarioRepository :IScenarioRepository
    {
        #region "Private Member(s)"

        readonly TestCaseManagementDbContext _dbContext;

        #endregion

        #region "Constructor"

        public ScenarioRepository(TestCaseManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region "Public Method(s)"

        public async Task<List<Scenario>> GetScenariosAsync(int projectId)
        {
            return await _dbContext.Scenario.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public async Task<Scenario> AddScenarioAsync(Scenario scenario)
        {
            await _dbContext.Scenario.AddAsync(scenario);
            await _dbContext.SaveChangesAsync();
            return scenario;
        }

        public async Task<Scenario> UpdateScenarioAsync(Scenario scenario)
        {
            _dbContext.Scenario.Update(scenario);
            await _dbContext.SaveChangesAsync();
            return scenario;
        }

        public async Task DeleteScenarioAsync(Scenario scenario)
        {
            _dbContext.Scenario.Remove(scenario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Scenario> GetScenarioAsync(int projectId,int scenarioId)
        {
            return await _dbContext.Scenario.FirstOrDefaultAsync(x => x.Id == scenarioId && x.ProjectId == projectId);
        }

        public async Task<bool> IsScenarioExistAsync(int scenarioId)
        {
            return await _dbContext.Scenario.AnyAsync(x => x.Id == scenarioId);
        }

        #endregion
    }
}
