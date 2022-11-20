using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NASA_APIs.Models
{
    public class Projects
    {
        [JsonPropertyName("projectId")]
        public int ProjectId { get; set; }

        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }
    }

    public class TechPortProjectsModel
    {
        [JsonPropertyName("projects")]
        public List<Projects> Projects { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
    }
}
