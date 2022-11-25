using NASA_APIs.Interfaces.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_APIs.Interfaces.Base.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<bool> ExistId(int id);
        Task<bool> Exist(T item);
        Task<int> GetCount();
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Get(int Skip, int Count);
        Task<IPage<T>> GetPage(int PageIndex, int PageSize);

        Task<T> GetById(int Id);

        Task<T> Add(T item);

        Task<T> Update(T item);

        Task<T> Delete(T item);

        Task<T> DeleteById(T item);


    }
    public interface IPage<T>
    {
        IEnumerable<T> Items { get; }
        int TotalCount { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalPagesCount => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
