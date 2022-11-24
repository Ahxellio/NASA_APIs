using NASA_APIs.Interfaces.Base.Entities;

namespace NASA_APIs.DAL.Entities.Base
{
    public abstract class NamedEntity : Entity, INamedEntity
    {
        public string Name { get; set; }
    }
}
