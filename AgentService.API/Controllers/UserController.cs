using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.Concrete.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentService.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJWTAuthenticationService authenticateManager;
        //IUserService manageUser;
        public UserController(/*IUserService manageUser,*/ IJWTAuthenticationService authenticateManager)
        {
            //this.manageUser = manageUser;
            this.authenticateManager = authenticateManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Login([FromBody] UserLogin userCredentials)
        {
            var loginUser = authenticateManager.Authenticate(userCredentials);

            if(loginUser != null)
            {
                return Ok(loginUser.TokenKey);

            }
            return NotFound("User not found!");
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Successful! You've Authenticated." };
        }
    } 
}
