using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class matchs
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public DateTime MatchDate { get; set; }
        public int ClubId { get; set; }

        public int PlayerAmount { get; set; }

        public int Price1 { get; set; }
        public int Price2 { get; set; }
        public DateTime CreateDate { get; set; }
        public string ActiveFlag { get; set; }
    }
}
 