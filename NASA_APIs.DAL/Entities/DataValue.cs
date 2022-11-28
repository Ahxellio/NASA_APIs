using Microsoft.EntityFrameworkCore;
using NASA_APIs.DAL.Entities.Base;
using System;
using System.Xml.Linq;

namespace NASA_APIs.DAL.Entities
{
    [Index(nameof(Time))]
    public class DataValue : Entity
    {
        public DateTimeOffset Time { get; set; } = DateTime.Now;
        public string Value { get; set; }
        public DataSource Source { get; set; }
        public bool IsFault { get; set; }
    }
}
