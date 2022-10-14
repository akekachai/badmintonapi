using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class clubmember
    {
        public int id { get; set; }
        public int clubid { get; set; }
        public string displayname { get; set; }
        public int userid { get; set; }
        public DateTime createdate { get; set; }
        public DateTime updatedate { get; set; }
        public string activeflag { get; set; }
    }
}
