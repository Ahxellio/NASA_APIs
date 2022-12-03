using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NASA_APIs.API.Controllers.Base;
using NASA_APIs.DAL.Entities;
using NASA_APIs.DAL.Entities.Base;
using NASA_APIs.Interfaces.Base.Repositories;

namespace NASA_APIs.API.Controllers
{
    
    [ApiController]
    public class DataSourcesController : EntityController<DataSource>
    {
        public DataSourcesController(IRepository<DataSource> Repository) : base( Repository) { }
    }
}
