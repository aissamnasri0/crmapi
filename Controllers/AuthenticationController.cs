using tpcrm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using tpcrm;

namespace JwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtAuthenticationService _jwtAuthenticationService;
        private readonly IConfiguration _config;
        private readonly CrmContext _Context;

        public AuthenticationController(JwtAuthenticationService JwtAuthenticationService, IConfiguration config,CrmContext Context)
        {
            _jwtAuthenticationService = JwtAuthenticationService;
            _config = config;
            _Context= Context;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user=_Context.users.Single(p=>p.Email.Equals(model.Email)&& p.Password.Equals(model.Password));
            var token = _jwtAuthenticationService.Authenticate(user);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}