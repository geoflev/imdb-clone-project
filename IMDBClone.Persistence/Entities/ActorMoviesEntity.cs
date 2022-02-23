using IMDBClone.Persistence.Entities;

namespace imdb_clone_models.Entities
{
    public class ActorMoviesEntity
    {
        public string ActorId { get; set; }
        public ActorEntity Actor { get; set; }
        public string MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
