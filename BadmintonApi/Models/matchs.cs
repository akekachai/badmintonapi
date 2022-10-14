using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class matchs
    {
        public int id { get; set; }
        public int matchid { get; set; }
        public DateTime matchdate { get; set; }
        public int clubid { get; set; }

        public int playeramount { get; set; }

        public int price1 { get; set; }
        public int price2 { get; set; }
        public DateTime createdate { get; set; }
        public string activeflag { get; set; }
    }
}
 