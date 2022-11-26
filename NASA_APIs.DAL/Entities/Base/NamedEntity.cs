using NASA_APIs.Interfaces.Base.Entities;
using System.ComponentModel.DataAnnotations;

namespace NASA_APIs.DAL.Entities.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
