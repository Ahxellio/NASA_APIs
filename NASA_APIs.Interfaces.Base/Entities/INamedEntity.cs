using System.ComponentModel.DataAnnotations;

namespace NASA_APIs.Interfaces.Base.Entities
{
    public interface INamedEntity : IEntity
    {
        [Required]
        string Name { get; }
    }
}
