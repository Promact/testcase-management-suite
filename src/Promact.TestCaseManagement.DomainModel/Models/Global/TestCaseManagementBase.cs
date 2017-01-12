using System;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.Global
{
    public class TestCaseManagementBase
    {
        #region Public Properties

        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        #endregion
    }
}