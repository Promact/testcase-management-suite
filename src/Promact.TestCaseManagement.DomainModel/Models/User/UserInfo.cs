using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Promact.TestCaseManagement.DomainModel.Models.User
{
    public class UserInfo
    {
        #region Public Properties

        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string RefreshToken { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<ProjectUserMapping> ProjectUserMapping { get; set; }

        #endregion
    }
}
