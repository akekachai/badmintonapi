using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class persons
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
