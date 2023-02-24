using Microsoft.EntityFrameworkCore;
using NASA_APIs.DAL.Context;
using NASA_APIs.DAL.Entities;
using System;
using System.Linq;

namespace NASA_APIs.API.Data
{
    public class DataDbInitializer
    {
        private readonly DataDB _db;

        public DataDbInitializer(DataDB db)
        {
            _db = db;
        }
        public void Initialize()
        {
            _db.Database.EnsureCreated();
            _db.Database.Migrate();
            _db.SaveChanges();
        }
    }
}
