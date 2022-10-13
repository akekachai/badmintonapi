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
    public class transactionmatchRepository : ItransactionmatchRepositories<transactionmatch, int>
    {
        private readonly BadmintonContext _context;

        public transactionmatchRepository(BadmintonContext context)
        {
            _context = context;
        }   

        public async Task<IReadOnlyList<transactionmatch>> GetByMatchId(int T2)
        {
            return await _context.transactionmatch.Where(tm => tm.MatchId == T2).ToListAsync();
        }

        public async Task<IReadOnlyList<transactionmatch>> GetByPlayerId(int T2)
        {
            return await _context.transactionmatch.Where(tm => tm.player_1 == T2 || tm.player_2 == T2 || tm.player_3 == T2 || tm.player_4 ==T2).ToListAsync();
        }

        public async Task Insert(transactionmatch entity)
        {
            await _context.transactionmatch.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(transactionmatch entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
