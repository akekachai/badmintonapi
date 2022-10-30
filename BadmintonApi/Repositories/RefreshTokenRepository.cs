using BadmintonApi.Data;
using BadmintonApi.Models;
using BadmintonApi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepositories<RefreshTokens, string>
    {
        private readonly BadmintonContext _context;
        public RefreshTokenRepository(BadmintonContext context)
        {
            _context = context;

        }

        public async Task<IReadOnlyList<RefreshTokens>> GetById(string id)
        {
            return await _context.RefreshTokens.Where(r => r.userid == id).ToListAsync();
        }

        public async Task Insert(RefreshTokens entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(RefreshTokens entity)
        {
            var data = await _context.RefreshTokens.SingleOrDefaultAsync(r => r.userid == entity.userid);
            data.jwtcode = entity.jwtcode;
            data.token = entity.token;

        }


    }
}
