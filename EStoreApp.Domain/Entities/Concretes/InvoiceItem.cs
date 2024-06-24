using EStoreApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Domain.Entities.Concretes
{
    public class InvoiceItem : BaseEntity
    {
        public decimal Quantity { get; set; }

        public int ProductId { get; set; }
        public int InvoiceId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
