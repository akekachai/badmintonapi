using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class RefreshTokens
    {
        public int id { get; set; }
        public string userid { get; set; }
        public string jwtcode { get; set; }
        public string token { get; set; }
        public DateTime expires { get; set; }
    }
}
