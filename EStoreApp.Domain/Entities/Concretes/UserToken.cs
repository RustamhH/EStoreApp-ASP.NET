using EStoreApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Domain.Entities.Concretes
{
    public class UserToken : BaseEntity
    {
        public string? Token { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpireTime { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

}
