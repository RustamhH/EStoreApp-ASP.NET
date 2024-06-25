using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Domain.ViewModels.User;
using EStoreApp.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace EStoreApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles ="SuperAdmin")]
public class SuperAdminController : ControllerBase
{
    // send Mail
    // admin crud
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public SuperAdminController(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }



    [HttpPost("[action]")]
    public async Task<IActionResult> AddAdmin([FromBody] AddAdminVM adminVM)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        using var hmac = new HMACSHA256();

        var userRole = await _roleRepository.GetRoleByRoleName("Admin");

        var newUser = new User()
        {
            UserName = adminVM.UserName,
            Email = adminVM.Email,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminVM.Password)),
            PasswordSalt = hmac.Key,
            Role = userRole!,
            RoleId = userRole!.Id,
            IsEmailConfirmed = true,
            Name = adminVM.Name,
            Surname = adminVM.Surname,
        };
        return Ok();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateAdmin(int id, [FromBody] UpdateUserVM updateUserVM)
    {


        if (id != updateUserVM.Id)
        {
            return BadRequest(new { Message = "Mismatch between route id and body id." });
        }

        var user = await _userRepository.GetByIdAsync(updateUserVM.Id);

        if (user == null)
            return BadRequest("NOT FOUND");


        using var hmac = new HMACSHA256();

        user.Name = updateUserVM.Name;
        user.UserName = updateUserVM.UserName;
        user.Email = updateUserVM.Email;
        user.Surname = updateUserVM.Surname;
        user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(updateUserVM.Password));
        user.PasswordSalt = hmac.Key;


        await _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();
        return Ok();



    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        var result = await _userRepository.Delete(id);
        await _userRepository.SaveChangesAsync();
        if (result == true)
        {
            return Ok(result);
        }
        return BadRequest("Admin Not Found");
    }


    [HttpPost("[action]/{role}")]
    public async Task SendMailToRoles(string role, [FromQuery] string messageText)
    {
        var Role=await _roleRepository.GetRoleByRoleName(role);
        var AllUsers = await _userRepository.GetAllAsync();
        if(role!="All")
        {
            foreach (var user in AllUsers)
            {
                if(user.RoleId==Role.Id)
                {
                    await SmtpService.SendMail(user.Email, "Message From SuperAdmin", messageText);
                }
            }
        }
        else
        {
            foreach (var user in AllUsers)
            {
                await SmtpService.SendMail(user.Email, "Message From SuperAdmin", messageText);   
            }
        }
    }


}
