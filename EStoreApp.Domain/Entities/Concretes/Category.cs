using EStoreApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Domain.Entities.Concretes
{
    public class Category:BaseEntity
    {
        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
