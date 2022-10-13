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
    }
}
