using NASA_APIs.DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_APIs.DAL.Entities
{
    public class DataSource : NamedEntity
    {
        public string Description { get; set; }
    }
    public class DataValue : Entity
    {
        public DateTimeOffset Time { get; set; } = DateTime.Now;
        public string Value { get; set; }
        public DataSource Source { get; set; }
        public bool IsFault { get; set; }
    }
}
