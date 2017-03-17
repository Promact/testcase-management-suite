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

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        #endregion
    }
}