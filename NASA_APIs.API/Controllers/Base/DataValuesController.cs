using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NASA_APIs.DAL.Entities;
using NASA_APIs.Interfaces.Base.Repositories;

namespace NASA_APIs.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataValuesController : EntityController<DataValue>
    {
        public DataValuesController(IRepository<DataValue> Repository) : base(Repository) { }
    }
}
