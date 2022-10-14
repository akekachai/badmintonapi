using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class transactionmatch
    {
        public int id { get; set; }
        public int matchid { get; set; }

        public int player_1 { get; set; }
        public int player_2 { get; set; }
        public int player_3 { get; set; }
        public int player_4 { get; set; }

        public string player_1result { get; set; }
        public string player_2result { get; set; }
        public string player_3result { get; set; }
        public string player_4result { get; set; }

        public string resultstatus { get; set; }
        public DateTime createdate { get; set; }
     
        public string activeflag { get; set; }
        public  string matchref { get; set; }

    }
}
 