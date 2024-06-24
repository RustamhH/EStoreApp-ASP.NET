using EStoreApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Domain.Entities.Concretes
{
    public class Role : BaseEntity
    {
        public string? Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
