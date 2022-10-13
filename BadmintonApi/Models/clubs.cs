using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Models
{
    public class clubs
    {
        public int Id { get; set; }
        public string ClubId { get; set; }
        public string DisplayName { get; set; }
        public string PathPicture { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateUserId { get; set; }
        public string ActiveFlag { get; set; }
    }
}
