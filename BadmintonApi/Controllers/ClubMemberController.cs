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
    public class ClubMemberController : ControllerBase
    {
        private readonly IclubmemberRepositories<clubmember, int> _iclubmemberRepositories;

        public ClubMemberController(IclubmemberRepositories<clubmember, int> iclubmemberRepositories)
        {
            _iclubmemberRepositories = iclubmemberRepositories;
        }

        [HttpPost]
        public async Task<IActionResult> insert(clubmember _clubmember)
        {
            try
            {
                await _iclubmemberRepositories.Insert(_clubmember);
                return Ok(new { sucess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        [HttpPatch]
        public async Task<IActionResult> update(clubmember _clubmember)
        {
            try
            {
                await _iclubmemberRepositories.Update(_clubmember);
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
                var data = await _iclubmemberRepositories.GetById(id);
                return Ok(new { data = data, suceess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }

        }
    }
}
