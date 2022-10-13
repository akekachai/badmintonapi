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

    }
}
