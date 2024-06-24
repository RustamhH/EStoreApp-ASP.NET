using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EStoreApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles ="SuperAdmin")]
public class SuperAdminController : ControllerBase
{
}
