using Promact.TestCaseManagement.DomainModel.Models.TestCase.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promact.TestCaseManagement.DomainModel.Models.TestCase
{
    public class TestCaseSteps : TestCaseStepsBase
    {
        #region Public Properties

        public int TestCaseId { get; set; }

        [ForeignKey("TestCaseId")]
        public virtual TestCase TestCase { get; set; }

        public virtual ICollection<TestCaseInput> TestCaseInputs { get; set; }

        #endregion
    }
}