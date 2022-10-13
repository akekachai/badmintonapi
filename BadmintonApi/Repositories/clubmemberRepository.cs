using BadmintonApi.Data;
using BadmintonApi.Models;
using BadmintonApi.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories
{
    public class clubmemberRepository : IclubmemberRepositories<clubmember, int>
    {
        private readonly BadmintonContext _context;

        public clubmemberRepository(BadmintonContext context)
        {
            _context = context;
        }

        

        public async Task<clubmember> GetById(int T2)
        {
            return await _context.clubmember.FindAsync(T2);
        }

        public async Task Insert(clubmember entity)
        {
            await _context.clubmember.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public  async Task Update(clubmember entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
