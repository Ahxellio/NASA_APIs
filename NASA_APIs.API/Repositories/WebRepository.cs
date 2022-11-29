using NASA_APIs.Interfaces.Base.Entities;
using NASA_APIs.Interfaces.Base.Repositories;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NASA_APIs.API.Repositories
{
    public class WebRepository<T> : IRepository<T> where T : IEntity, new()
    {
        private readonly HttpClient _Client;

        public WebRepository(HttpClient Client)=> _Client = Client;

        Task<T> IRepository<T>.Add(T item, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        Task<T> IRepository<T>.Delete(T item, CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }

        Task<T> IRepository<T>.DeleteById(int Id, CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IRepository<T>.Exist(T item, CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IRepository<T>.ExistId(int Id, CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository<T>.Get(int Skip, int Count, CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository<T>.GetAll(CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }

        Task<T> IRepository<T>.GetById(int Id, CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }

        Task<int> IRepository<T>.GetCount(CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }

        Task<IPage<T>> IRepository<T>.GetPage(int PageIndex, int PageSize, CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }

        Task<T> IRepository<T>.Update(T item, CancellationToken Cancel)
        {
            throw new System.NotImplementedException();
        }
    }
}
