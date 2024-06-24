using EStoreApp.Application.Services;
using EStoreApp.Domain.ViewModels.Category;
using EStoreApp.Domain.ViewModels.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EStoreApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpPost("[action]")]
    [Authorize(Roles = "Cashier")]
    public async Task<IActionResult> AddInvoice([FromBody] AddInvoiceVM addinvoiceVM)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _invoiceService.AddInoviceAsync(addinvoiceVM);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllInvoices()
    {
        var invoices = await _invoiceService.GetAllInvoices();
        return Ok(invoices);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var invoice = await _invoiceService.GetInvoiceById(id);
        if (invoice == null)
        {
            return NotFound();
        }
        return Ok(invoice);

    }

    [HttpDelete("[action]/{id}")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var response = await _invoiceService.DeleteInvoiceAsync(id);
        if (response == true)
        {
            return Ok(response);
        }
        return BadRequest("Invoice Not Found");
    }
    
    
    
    [HttpDelete("[action]/{id}")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> CreateRefundInvoice(int invoiceId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _invoiceService.CreateRefundInvoiceAsync(invoiceId);
        return Ok();

    }
}
