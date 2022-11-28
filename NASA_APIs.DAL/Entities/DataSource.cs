using Microsoft.EntityFrameworkCore;
using NASA_APIs.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_APIs.DAL.Entities
{
    [Index(nameof(Name))]
    public class DataSource : NamedEntity
    {
        public string Description { get; set; }
    }
}
