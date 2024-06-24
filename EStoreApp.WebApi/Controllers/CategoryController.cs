using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Application.Services;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Domain.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace EStoreApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryVM categoryVM)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _categoryService.AddCategoryAsync(categoryVM);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);

    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryVM updateCategoryVM)
    {
        try
        {
            if (id != updateCategoryVM.Id)
            {
                return BadRequest(new { Message = "Mismatch between route id and body id." });
            }

            var response = await _categoryService.UpdateCategoryAsync(updateCategoryVM);
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
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var response = await _categoryService.DeleteCategoryAsync(id);
        if(response==true)
        {
            return Ok(response);
        }
        return BadRequest("Category Not Found");
    }
}
