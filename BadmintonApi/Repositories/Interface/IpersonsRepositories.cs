using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories.Interface
{
    public interface IpersonsRepositories<T1, T2,T3> where T1 : class
    {
        Task Insert(T1 entity);
        Task Update(T1 entity);
        Task<T1> GetById(int T2);
        Task<IReadOnlyList<T1>> GetByUserId(string T3);
    }
}
