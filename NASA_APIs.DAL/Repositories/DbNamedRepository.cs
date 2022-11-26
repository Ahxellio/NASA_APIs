using Microsoft.EntityFrameworkCore;
using NASA_APIs.DAL.Context;
using NASA_APIs.DAL.Entities.Base;
using NASA_APIs.Interfaces.Base.Entities;
using NASA_APIs.Interfaces.Base.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NASA_APIs.DAL.Repositories
{
    public class DbNamedRepository<T> : DbRepository<T>, INamedRepository<T> where T : NamedEntity, new()
    {
        public DbNamedRepository(DataDB db) : base(db) { }

        public async Task<T> DeleteByName(string Name, CancellationToken Cancel = default)
        {
            var item = Set.Local.FirstOrDefault(i => i.Name == Name);
            if (item is null)
                item = await Set
                    .Select(i => new T {Id = i.Id, Name = i.Name })
                    .FirstOrDefaultAsync(i => i.Name == Name, Cancel)
                    .ConfigureAwait(false);
            if (item is null) return null;
            return await Delete(item, Cancel).ConfigureAwait(false);
        }

        public async Task<bool> ExistName(string Name, CancellationToken Cancel = default)
        {
            return await Items.AnyAsync(item => item.Name == Name, Cancel).ConfigureAwait(false);
        }

        public async Task<T> GetByName(string Name, CancellationToken Cancel = default)
        {
            return await Items.FirstOrDefaultAsync(item => item.Name == Name, Cancel).ConfigureAwait(false);
        }
    }
}
