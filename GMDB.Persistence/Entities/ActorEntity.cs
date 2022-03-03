using System.Collections.Generic;

namespace GMDB.Persistence.Entities
{
    public class ActorEntity : PersonEntity
    {
        public int ActingScore { get; set; }
        public ICollection<ActorMoviesEntity> Movies { get; set; }
    }
}
