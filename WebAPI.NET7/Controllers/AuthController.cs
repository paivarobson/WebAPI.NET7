using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.NET7.Domain.Model;
using WebAPI.NET7.Application.Services;

namespace WebAPI.NET7.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string userName, string password)
        {
            if (userName == "paiva" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Employee());

                return Ok(token);
            }

            return BadRequest("Usuário ou senha inválido");
        }
    }
}