using Microsoft.EntityFrameworkCore;
using NASA_APIs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_APIs.DAL.Context
{
    public class DataDB : DbContext
    {
        public DbSet<ApodValue> ApodValue { get; set; }
        public DataDB(DbContextOptions<DataDB> options) : base(options) { Database.EnsureCreated(); }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }

    }
}
