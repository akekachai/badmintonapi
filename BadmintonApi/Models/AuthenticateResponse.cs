using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class AuthenticateResponse
    {
        public int id { get; set; }
        public string userid { get; set; }

        public string displaynamae { get; set; }
        public string activeflag { get; set; }

 
        public string jwttoken { get; set; }


        // [JsonIgnore] // refresh token is returned in http only cookie
        public string refreshtoken { get; set; }

        public AuthenticateResponse(persons persons, string jwtToken, string refreshToken)
        {
            id = persons.id;
            userid = persons.userid;
            displaynamae = persons.displayname;
            jwttoken = jwtToken;
            refreshtoken = refreshToken;
        }
    }
}
