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
        public async Task AddInvoiceAsync(AddInvoiceVM addInvoiceVM)
        {
            Random random = new Random();
            string barcodeString = "";
            for (int i = 0; i < 12; i++)
            {
                barcodeString += random.Next(0, 10).ToString();
            }
            long barcode = long.Parse(barcodeString);



            var invoice = new Invoice
            {
                Barcode=barcode,
                CashierId=addInvoiceVM.CashierId,
                CustomerId=addInvoiceVM.CustomerId,
                InvoiceItems=addInvoiceVM.InvoiceItems,
                InvoiceType=InvoiceType.Sell,
            };
            await _invoiceRepository.Add(invoice);
            await _invoiceRepository.SaveChangesAsync();
        }

        public async Task CreateRefundInvoiceAsync(int invoiceId)
        {
            var invoice=await _invoiceRepository.GetByIdAsync(invoiceId);
            invoice.InvoiceType = InvoiceType.Refund;
            await _invoiceRepository.Update(invoice);
            await _invoiceRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteInvoiceAsync(int id)
        {
            var result = await _invoiceRepository.Delete(id);
            await _invoiceRepository.SaveChangesAsync();
            return result;
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {
            return (await _invoiceRepository.GetAllAsync()).ToList();
        }

        public async Task<Invoice> GetInvoiceById(int id)
        {
            return await _invoiceRepository.GetByIdAsync(id);
        }
    }
}
