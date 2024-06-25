using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Domain.ViewModels.Category;
using EStoreApp.Domain.ViewModels.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EStoreApp.Application.Services
{
    public interface IInvoiceService
    {
        Task AddInvoiceAsync(AddInvoiceVM addInvoiceRequestDTO);
        Task<List<Invoice>> GetAllInvoices();
        Task<Invoice> GetInvoiceById(int id);
        Task<bool> DeleteInvoiceAsync(int id);
        Task CreateRefundInvoiceAsync(int invoiceId);
    }
}
