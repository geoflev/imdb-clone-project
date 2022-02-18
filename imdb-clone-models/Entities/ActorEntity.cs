using IMDBClone.Persistence.Entities;
using System.Collections.Generic;

namespace imdb_clone_models.Entities
{
    public class ActorEntity : PersonEntity
    {
        public int ActingScore { get; set; }
        public ICollection<ActorMoviesEntity> Movies { get; set; }
    }
}
