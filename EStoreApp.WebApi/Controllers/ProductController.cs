using EStoreApp.Application.Services;
using EStoreApp.Domain.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EStoreApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("[action]")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductVM productVM)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _productService.AddProductAsync(productVM);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);

    }
    
    [HttpGet("[action]/{name}")]
    public async Task<IActionResult> GetProductByCategoryName(string name)
    {
        var product = await _productService.GetProductByCategoryName(name);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);

    }

    [HttpPut("[action]")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductVM updateProductVM)
    {
        try
        {
            if (id != updateProductVM.Id)
            {
                return BadRequest(new { Message = "Mismatch between route id and body id." });
            }
            var response = await _productService.UpdateProductAsync(updateProductVM);
            if (response == HttpStatusCode.NoContent)
            {
                return NoContent();
            }
            else if (response == HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            else
            {
                return StatusCode((int)response, new { Message = response });
            }
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = ex.Message });
        }

    }

    [HttpDelete("[action]/{id}")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var response = await _productService.DeleteProductAsync(id);
        if (response == true)
        {
            return Ok(response);
        }
        return BadRequest("Product Not Found");
    }
}
