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
    }
}
