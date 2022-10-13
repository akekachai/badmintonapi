using BadmintonApi.Data;
using BadmintonApi.Models;
using BadmintonApi.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories
{
    public class matchRepository : ImatchRepositories<matchs, int>
    {
        private readonly BadmintonContext _context;

        public matchRepository(BadmintonContext context)
        {
            _context = context;
        }

       

        public async Task<matchs> GetById(int T2)
        {
            return await _context.matchs.FindAsync(T2);
        }

        public   async Task Insert(matchs entity)
        {
            await _context.matchs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(matchs entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
