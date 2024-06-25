using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Application.Services;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Domain.Enums;
using EStoreApp.Domain.ViewModels.Category;
using EStoreApp.Domain.ViewModels.Invoice;
using EStoreApp.Persistence.Repositories.Concretes;

namespace EStoreApp.Persistence.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public Task AddInvoiceAsync(AddInvoiceVM addInvoiceVM)
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
