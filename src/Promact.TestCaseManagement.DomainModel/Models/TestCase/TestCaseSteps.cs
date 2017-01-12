using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseSteps : TestCaseStepsBase
    {
        #region Constructors

        public TestCaseSteps()
        {
            TestCaseInputs = new List<TestCaseInput>();
        }

        #endregion

        #region Public Properties
        
        public int TestCaseResultId { get; set; }

        public int TestCaseId { get; set; }

        [ForeignKey("TestCaseResultId")]
        public virtual TestCaseResult TestCaseResult { get; set; }

        [ForeignKey("TestCaseId")]
        public virtual TestCase TestCase { get; set; }

        public virtual ICollection<TestCaseInput> TestCaseInputs { get; set; }

        #endregion
    }
}