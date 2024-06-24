using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Persistence.Contexts;
using EStoreApp.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Persistence.Repositories.Concretes
{
    public class InvoiceItemRepository: GenericRepository<InvoiceItem>, IInvoiceItemRepository
    {
        public InvoiceItemRepository(AppDbContext context) : base(context) { }

    }
}
