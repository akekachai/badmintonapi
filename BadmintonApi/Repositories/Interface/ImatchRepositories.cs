using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadmintonApi.Repositories.Interface
{
   public interface ImatchRepositories<T1, T2> where T1 : class
    {
        Task Insert(T1 entity);
        Task Update(T1 entity);
        Task<T1> GetById(int T2);
    }
}
