using Microsoft.AspNetCore.Mvc;
using NASA_APIs.API.Controllers.Base;
using NASA_APIs.DAL.Entities;
using NASA_APIs.Interfaces.Base.Repositories;

namespace NASA_APIs.API.Controllers
{
    [ApiController]
    public class ApodValueController : EntityController<ApodValue>
    {
        public ApodValueController(IRepository<ApodValue> Repository) : base(Repository) { }
    }
}
