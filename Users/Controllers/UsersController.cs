using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Users.Contracts.Users;
using Users.Core.Users;
using Users.Models.Users;
using Users.Services.Interfaces;

namespace Users.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Method returns all users")]
        [SwaggerResponse(200, null, typeof(List<UserContract>))]
        public async Task<IActionResult> Get()
        {
            var model = await _usersService.GetAsync();
            var result = _mapper.Map<List<UserContract>>(model);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Method returns user info")]
        [SwaggerResponse(200, null, typeof(UserContract))]
        public async Task<IActionResult> GetById(
        [SwaggerParameter("User id", Required = true)]
        Guid id)
        {
            var model = await _usersService.GetByIdAsync(id);

            if (model == null)
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            var result = _mapper.Map<UserContract>(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Method for updating user")]
        [SwaggerResponse(200, null, typeof(UserContract))]
        public async Task<IActionResult> Update(
        [SwaggerParameter("User id", Required = true)]
        Guid id, [FromBody] CreateUserContract contract)
        {
            var model = _mapper.Map<UserModel>(contract);
            model.Id = id;
            var updatedModel = await _usersService.UpdateAsync(model);

            if (updatedModel == null)
            {
                return NotFound(ErrorMessages.UserNotFound);
            }

            var result = _mapper.Map<UserContract>(updatedModel);
            return Ok(result);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Method for creating user")]
        [SwaggerResponse(200, null, typeof(UserContract))]
        public async Task<IActionResult> Create([FromBody] CreateUserContract contract)
        {
            var model = _mapper.Map<UserModel>(contract);
            var createdModel = await _usersService.CreateAsync(model);
            var result = _mapper.Map<UserContract>(createdModel);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Method for deleting  user")]
        [SwaggerResponse(200, null, null)]
        public async Task<IActionResult> Delete(
        [SwaggerParameter("User id", Required = true)] Guid id)
        {
            await _usersService.RemoveAsync(id);

            return Ok();
        }

    }
}
