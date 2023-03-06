using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NASA_APIs.DAL.Entities
{
    public class TechPortProjectsValue
    {
        [JsonPropertyName("projects")]
        public List<Projects> Projects { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
    }
    public class Projects
    {
        [JsonPropertyName("projectId")]
        public int ProjectId { get; set; }

        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }
    }
}
