using EStoreApp.Application.Repositories.Concretes;
using EStoreApp.Domain.Dtos;
using EStoreApp.Domain.Entities.Concretes;
using EStoreApp.Domain.ViewModels.Category;
using EStoreApp.Domain.ViewModels.User;
using EStoreApp.Persistence.Repositories.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace EStoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }



        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser([FromBody] AddUserVM userVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using var hmac = new HMACSHA256();

            var userRole = await _roleRepository.GetRoleByRoleName(userVM.RoleName);
            
            var newUser = new User()
            {
                UserName = userVM.UserName,
                Email = userVM.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userVM.Password)),
                PasswordSalt = hmac.Key,
                Role = userRole!,
                RoleId = userRole!.Id,
                IsEmailConfirmed = true,
                Name = userVM.Name,
                Surname = userVM.Surname,
            };

            await _userRepository.Add(newUser);
            await _userRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("[action]/{id}")]

        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }   

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserVM updateUserVM)
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
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userRepository.Delete(id);
            await _userRepository.SaveChangesAsync();
            if (result == true)
            {
                return Ok(result);
            }
            return BadRequest("User Not Found");
        }



    }
}
