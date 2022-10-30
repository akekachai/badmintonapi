using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class persons
    {

        public int id { get; set; }
        public string userid { get; set; }
        public string displayname { get; set; }
        public DateTime createdate { get; set; }
        public int createuserid { get; set; }
        public DateTime updatedate { get; set; }
        public int updateuserid { get; set; }
        public string activeflag { get; set; }
        public string? password { get; set; }
        public string? jwtcode { get; set; }

        public string? refreshtoken { get; set; }
        public DateTime? expirestoken { get; set; }

    }
}
