using Personas.api.Models;
using Personas.api.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Personas.api.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest request)
        {
            if (request.User == "admin" && request.Password == "123")
            {
                var jwt = new JwtService();
                var token = jwt.GenerateToken(request.User);

                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}