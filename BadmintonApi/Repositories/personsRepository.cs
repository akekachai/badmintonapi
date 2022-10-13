using BadmintonApi.Data;
using BadmintonApi.Models;
using BadmintonApi.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories
{
    public class personsRepository : IpersonsRepositories<persons, int>
    {
        private readonly BadmintonContext _context;

        public personsRepository(BadmintonContext context)
        {
            _context = context;
        }

        
        public async Task<persons> GetById(int T2)
        {
            return await _context.persons.FindAsync(T2);
        }

        public async Task Insert(persons entity)
        {
            await _context.persons.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(persons entity)
        {
             _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
