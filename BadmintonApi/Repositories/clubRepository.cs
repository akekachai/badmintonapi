using BadmintonApi.Data;
using BadmintonApi.Models;
using BadmintonApi.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories
{
    public class clubRepository : IclubRepositories<clubs, int>
    {
        private readonly BadmintonContext _context;

        public clubRepository(BadmintonContext context)
        {
            _context = context;
        }

        

        public async Task<clubs> GetById(int T2)
        {
            return await _context.clubs.FindAsync(T2);
        }

        public async Task Insert(clubs entity)
        {
            await _context.clubs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(clubs entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

       
    }
}
