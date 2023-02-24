using NASA_APIs.Interfaces.Base.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASA_APIs.Interfaces.Base.Entities
{
    public interface IAPODEntity
    {
        public string Date { get; set; }

        public string Text { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }
    }
}
