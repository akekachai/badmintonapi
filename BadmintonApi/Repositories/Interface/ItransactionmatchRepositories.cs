using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories.Interface
{
   public interface ItransactionmatchRepositories<T1, T2> where T1 : class
    {
        Task Insert(T1 entity);
        Task Update(T1 entity);
        Task<IReadOnlyList<T1>> GetByPlayerId(int T2);
        Task<IReadOnlyList<T1>> GetByMatchId(int T2);
    }
}
