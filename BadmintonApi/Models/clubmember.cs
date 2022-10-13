using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class clubmember
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public string DisplayName { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ActiveFlag { get; set; }
    }
}
