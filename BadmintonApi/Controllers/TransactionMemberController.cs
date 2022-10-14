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
    public class TransactionMemberController : ControllerBase
    {
        private readonly ItransactionmatchRepositories<transactionmatch, int> _itransactionmatchRepositories;
        public TransactionMemberController(ItransactionmatchRepositories<transactionmatch, int> itransactionmatchRepositories)
        {
            _itransactionmatchRepositories = itransactionmatchRepositories;
        }



        [HttpPost]
        public async Task<IActionResult> insert(transactionmatch _transactionmatch)
        {
            try
            {
                await _itransactionmatchRepositories.Insert(_transactionmatch);
                return Ok(new { sucess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }


        [HttpPatch]
        public async Task<IActionResult> update(transactionmatch transactionmatch)
        {
            try
            {
                await _itransactionmatchRepositories.Update(transactionmatch);
                return Ok(new { sucess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("playerid")]
        public async Task<IActionResult> get(int playerid)
        {
            try
            {
                var data = await _itransactionmatchRepositories.GetByPlayerId(playerid);
                return Ok(new { data = data, suceess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }

        }

        [HttpGet("matchid")]
        public async Task<IActionResult> getmatch(int matchid)
        {
            try
            {
                var data = await _itransactionmatchRepositories.GetByMatchId(matchid);
                return Ok(new { data = data, suceess = true, message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }

        }

    }
}
