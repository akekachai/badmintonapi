using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class transactionmatch
    {
        public int Id { get; set; }
        public int MatchId { get; set; }

        public int player_1 { get; set; }
        public int player_2 { get; set; }
        public int player_3 { get; set; }
        public int player_4 { get; set; }

        public string Player_1Result { get; set; }
        public string Player_2Result { get; set; }
        public string Player_3Result { get; set; }
        public string Player_4Result { get; set; }

        public string ResultStatus { get; set; }
        public DateTime CreateDate { get; set; }
     
        public string ActiveFlag { get; set; }

    }
}
 