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
    public class ClubsController : ControllerBase
    {
        private readonly IclubRepositories<clubs, int> _iclubRepositories;
        public ClubsController(IclubRepositories<clubs, int> iclubRepositories)
        {
            _iclubRepositories = iclubRepositories;
        }


        [HttpPost]
        public async Task<IActionResult> insert(clubs _clubs)
        {
            try
            {
                await _iclubRepositories.Insert(_clubs);
                return Ok(new { sucess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        [HttpPatch]
        public async Task<IActionResult> update(clubs _clubs)
        {
            try
            {
                await _iclubRepositories.Update(_clubs);
                return Ok(new { sucess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> get(int id)
        {
            try
            {
                var data = await _iclubRepositories.GetById(id);
                return Ok(new { data = data, suceess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }

        }
    }
}
