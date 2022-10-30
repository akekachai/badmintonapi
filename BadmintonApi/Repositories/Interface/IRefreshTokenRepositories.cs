using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories.Interface
{
    public interface IRefreshTokenRepositories<T1, T2> where T1 : class
    {
        Task<IReadOnlyList<T1>> GetById(T2 id);
        Task Insert(T1 entity);
        Task Update(T1 entity);
        Task Save();
    }
}
