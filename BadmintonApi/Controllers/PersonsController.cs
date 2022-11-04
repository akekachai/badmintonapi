using BadmintonApi.Models;
using BadmintonApi.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace BadmintonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IpersonsRepositories<persons, int,string> _ipersonsRepositories;
        public PersonsController(IpersonsRepositories<persons, int,string> ipersonsRepositories)
        {
            _ipersonsRepositories = ipersonsRepositories;
        }

        [HttpPost]
        public async Task<IActionResult> insert(persons _persons)
        {
            try
            {
                await _ipersonsRepositories.Insert(_persons);
                return Ok(new { sucess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        [HttpPatch]
        public async Task<IActionResult> update(persons _persons)
        {
            try
            {
                await _ipersonsRepositories.Update(_persons);
                return Ok(new { sucess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> get()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IList<Claim> claim = identity.Claims.ToList();
                var userid = claim[0].Value;

                var data = await _ipersonsRepositories.GetByUserId(userid);
                return Ok(new { data = data, suceess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }

        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest model)
        {

            var response = _ipersonsRepositories.Authenticate(model, ipAddress());

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            setTokenCookie(response.refreshtoken);

            var data = new { fullName = response.displaynamae, userid = response.userid, status = response.activeflag };
            return Ok(new { data = data, jwtToken = response.jwttoken, refreshToken = response.refreshtoken });
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken([FromBody] JsonElement json)
        {

            JObject _result = JObject.Parse(json.ToString());
            var refreshToken = _result["refreshToken"].ToString();


            var response = _ipersonsRepositories.RefreshToken(refreshToken, ipAddress());

            if (response == null)
                return Unauthorized(new { message = "Invalid token" });

            setTokenCookie(response.refreshtoken);


            var data = new { fullName = response.displaynamae, userid = response.userid, status = response.activeflag };
            return Ok(new { data = data, jwtToken = response.jwttoken, refreshToken = response.refreshtoken });

        }

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(16)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
