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
    public class MatchsController : ControllerBase
    {
        private readonly ImatchRepositories<matchs, int> _imatchRepositories;
        public MatchsController(ImatchRepositories<matchs, int> imatchRepositories)
        {
            _imatchRepositories = imatchRepositories;
        }



        [HttpPost]
        public async Task<IActionResult> insert(matchs _matchs)
        {
            try
            {
                await _imatchRepositories.Insert(_matchs);
                return Ok(new { sucess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        [HttpPatch]
        public async Task<IActionResult> update(matchs _matchs)
        {
            try
            {
                await _imatchRepositories.Update(_matchs);
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
                var data = await _imatchRepositories.GetById(id);
                return Ok(new { data = data, suceess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }

        }
    }
}
