using NASA_APIs.Interfaces.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NASA_APIs.Interfaces.Base.Repositories
{
    public interface INamedRepository <T>: IRepository<T> where T : INamedEntity
    {
        Task<bool> ExistName(string Name, CancellationToken Cancel = default);
        Task<T> GetByName(string Name, CancellationToken Cancel = default);
        Task<T> DeleteByName(string Name, CancellationToken Cancel = default);
    }
}
