using BadmintonApi.Models;
using BadmintonApi.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IpersonsRepositories<persons, int> _ipersonsRepositories;
        public PersonsController(IpersonsRepositories<persons, int> ipersonsRepositories)
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

        [HttpGet]
        public async Task<IActionResult> get(persons _persons)
        { 
        
        }
    }
}
