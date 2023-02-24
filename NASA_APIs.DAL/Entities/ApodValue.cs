using Microsoft.EntityFrameworkCore;
using NASA_APIs.DAL.Entities.Base;
using NASA_APIs.Interfaces.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASA_APIs.DAL.Entities
{
    [Index(nameof(Id))]
    public class ApodValue : Entity, IAPODEntity
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("explanation")]
        public string Text { get; set; }

        [JsonPropertyName("hdurl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("media_type")]
        public string Type { get; set; }

        
    }
}
