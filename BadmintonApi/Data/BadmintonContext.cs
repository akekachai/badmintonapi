using BadmintonApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Data
{
    public class BadmintonContext:DbContext
    {
        public BadmintonContext()
        {
        }

        public BadmintonContext(DbContextOptions<BadmintonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<persons> persons { get; set; }
        public virtual DbSet<clubs> clubs { get; set; }
        public virtual DbSet<clubmember> clubmember { get; set; }
        public virtual DbSet<matchs> matchs { get; set; }
        public virtual DbSet<transactionmatch> transactionmatch { get; set; }

    }
}
