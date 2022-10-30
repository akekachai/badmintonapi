using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string userid { get; set; }

        public string password { get; set; }
    }
}
