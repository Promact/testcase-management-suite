using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.Repository.ApplicationClass.Scenario
{
    public class ScenarioAC
    {
        [Required]
        public string Name { get; set; }
    }
}
