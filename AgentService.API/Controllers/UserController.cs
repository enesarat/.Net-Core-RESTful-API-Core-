using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using EntityLayer.Concrete.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AgentService.API.Controllers
{
    [Route("api/[controller]")]     
    [ApiController]                 
    public class UserController : ControllerBase
    {
        private readonly IJWTAuthenticationService authenticateManager;
        private readonly IRsaHelperService _rsaManager;

        public UserController(IJWTAuthenticationService authenticateManager, IRsaHelperService rsaManager)
        {
            this.authenticateManager = authenticateManager;
            this._rsaManager = rsaManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticateTest")]
        public IActionResult LoginTest([FromBody] UserLogin userCredentials)
        {
            var loginUser = authenticateManager.Authenticate(userCredentials);

            if(loginUser != null)
            {
                return Ok(loginUser.TokenKey);

            }
            return NotFound("User not found!");
        }


        //***********************************************************
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Login([FromBody] UserLogin userCredentials)
        {
            var clearTextPassword = _rsaManager.Decrypt(userCredentials.Password);
            userCredentials.Password = clearTextPassword;
            var loginUser = authenticateManager.Authenticate(userCredentials);

            if (loginUser != null)
            {
                return Ok(loginUser.TokenKey);

            }
            return NotFound("User not found!");
        }
        //************************************************************


        [HttpGet("Admin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoit()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Successful! You've Authenticated. Welcome {currentUser.Role}" +$" {currentUser.UserName}");
            //return RedirectToAction("Get", "Agent");
        }

        [HttpGet("Manager")]
        [Authorize(Roles = "Manager,Administrator")]
        public IActionResult ManagerEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Successful! You've Authenticated. Welcome {currentUser.Role}" + $" {currentUser.UserName}");
        }

        [HttpGet("Expert")]
        [Authorize(Roles = "Expert,Administrator")]
        public IActionResult ExpertEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Successful! You've Authenticated. Welcome {currentUser.Role}" + $" {currentUser.UserName}");
        }


        private UserLogin GetCurrentUser()
        {
            var id = HttpContext.User.Identity as ClaimsIdentity;

            if (id != null)
            {
                var userClaims = id.Claims;
                var currentUser = new UserLogin();

                currentUser.UserId = int.Parse(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value);
                currentUser.UserName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
                currentUser.Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value;
                return currentUser;
            }
            return null;
        }
    } 
}
