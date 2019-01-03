using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneytrackercore.data.Entities;
using moneytrackercore.Services;

namespace moneytrackercore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        [HttpGet("{id}", Name = "UserGet")]
        public IActionResult GetUser(int id)
        {
            return Ok(_userRepository.GetUser(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Users model)
        {
            try
            {
                _userRepository.Add(model);
                if (await _userRepository.SaveAllAsync())
                {
                    var newUri = Url.Link("UserGet", new { id = model.Id });
                    return Created(newUri,model);
                }
            }
            catch (Exception)
            {

            }
            return BadRequest();
        }
    }
}