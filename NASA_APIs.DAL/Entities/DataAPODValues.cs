using Microsoft.EntityFrameworkCore;
using NASA_APIs.DAL.Entities.Base;
using NASA_APIs.Interfaces.Base.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_APIs.DAL.Entities
{
    [Index(nameof(Title))]
    public class DataAPODValues : NamedEntity, IAPODEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Text { get ; set ; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Title { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
    }
}
