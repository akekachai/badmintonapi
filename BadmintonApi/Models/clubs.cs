using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class clubs
    {
        public int id { get; set; }
        public string clubid { get; set; }
        public string displayname { get; set; }
        public string pathpicture { get; set; }
        public int ownerid { get; set; }
        public DateTime createdate { get; set; }
        public int createuserid { get; set; }
        public DateTime updatedate { get; set; }
        public int updateuserid { get; set; }
        public string activeflag { get; set; }
    }
}
