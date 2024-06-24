using EStoreApp.Application.Services;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Domain.ViewModels.Invoice;

namespace EStoreApp.Persistence.Services
{
    public class InvoiceService : IInvoiceService
    {
        public Task AddInoviceAsync(AddInvoiceVM addInvoiceVM)
        {
            throw new NotImplementedException();
        }

        public Task CreateRefundInvoiceAsync(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteInvoiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetAllInvoices()
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> GetInvoiceById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
