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

    }
}
