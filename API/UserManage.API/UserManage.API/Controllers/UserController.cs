using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using UserManage.API.Data;
using UserManage.API.Models.Domain;
using UserManage.API.Models.DTO;
using UserManage.API.Repositories.Interface;

namespace UserManage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto request)
        {
            var user = new User
            {
                firstName = request.firstName,
                lastName = request.lastName,
                email = request.email,
                phone = request.phone,
                roleId = request.roleId,
                username = request.username,
                password = request.password,
                permission = request.permission
            };

            await userRepository.CreateAsync(user);

            var response = new UserDto
            {
                id = user.id,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                phone = user.phone,
                roleId = user.roleId,
                username = user.username,
                password = user.password,
                permission = user.permission

            };

            return Ok();
        }

        //GET: https://localhost:7231/api/User
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await userRepository.GetAllAsync();

            var response = new List<UserDto>();
            foreach (var user in users)
            {
                response.Add(new UserDto
                {
                    id = user.id,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    email = user.email,
                    phone = user.phone,
                    roleId = user.roleId,
                    username = user.username,
                    password = user.password,
                    permission = user.permission
                });
            }

            return Ok(response);
        }

        //GET: https://localhost:7231/api/User/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id) 
        {
            var existingUser = await userRepository.GetById(id);

            if (existingUser is null)
                return NotFound();

            var response = new UserDto
            {
                id = existingUser.id,
                firstName = existingUser.firstName,
                lastName = existingUser.lastName,
                email = existingUser.email,
                phone = existingUser.phone,
                roleId = existingUser.roleId,
                username = existingUser.username,
                password = existingUser.password,
                permission = existingUser.permission
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditUser([FromRoute] Guid id, UpdateUserRequestDto request) 
        {
            var user = new User
            {
                id = id,
                firstName = request.firstName,
                lastName = request.lastName,
                email = request.email,
                phone = request.phone,
                roleId = request.roleId,
                username = request.username,
                password = request.password,
                permission = request.permission
            };

            user = await userRepository.UpdateAsync(user);

            if (user != null) 
            {
                return NotFound();
            }

            var response = new UserDto
            {
                id = user.id,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                phone = user.phone,
                roleId = user.roleId,
                username = user.username,
                password = user.password,
                permission = user.permission
            };

            return Ok(response);
        }

        //DELETE: https://localhost:7231/api/User/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id) 
        {
            var user = await userRepository.DeleteAsync(id);
            if (user is null)
                return NotFound();

            var response = new UserDto
            {
                id = user.id,
                firstName = user.firstName,
                lastName = user.lastName,
                email = user.email,
                phone = user.phone,
                roleId = user.roleId,
                username = user.username,
                password = user.password,
                permission = user.permission
            };

            return Ok(response);

        }
    }
}
