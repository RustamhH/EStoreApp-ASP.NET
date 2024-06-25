﻿using EStoreApp.Domain.Entities.Common;
using EStoreApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Domain.Entities.Concretes
{
    public class Invoice : BaseEntity
    {
        public long Barcode { get; set; }
        public InvoiceType InvoiceType { get; set; }

        public int CashierId { get; set; }
        public int CustomerId { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
