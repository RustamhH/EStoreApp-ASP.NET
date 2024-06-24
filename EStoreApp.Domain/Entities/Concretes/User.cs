using EStoreApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Domain.Entities.Concretes
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public bool? IsEmailConfirmed { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }


        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }
    }
}
