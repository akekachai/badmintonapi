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

    }
}
