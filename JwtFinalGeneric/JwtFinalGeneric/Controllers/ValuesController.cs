using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtFinalGeneric.DTO;
using JwtFinalGeneric.Interfaces;
using JwtFinalGeneric.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtFinalGeneric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly IUserRepository _userRepository;

        public ValuesController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] List<UserDto> userDtos)
        {
            Console.WriteLine(userDtos);
            foreach (var item in userDtos)
            {
                User user = new User()
                {
                    //id = item.id,
                    firstname = item.firstname,
                    lastname = item.lastname,
                    username = item.username,
                    password = item.password,
                    token = item.token
                };
                var result = _userRepository.FindUsername(user.username);
                if (result == null)
                {
                    _userRepository.Insert(user);
                }
            }
            return new JsonResult(_userRepository.List());
        }

        // GET api/values
        [HttpGet]
        public IActionResult GetUsers()
        {
            return new JsonResult(_userRepository.List());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
