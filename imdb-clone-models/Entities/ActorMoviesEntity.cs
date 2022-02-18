using IMDBClone.Persistence.Entities;

namespace imdb_clone_models.Entities
{
    public class ActorMoviesEntity
    {
        public int ActorId { get; set; }
        public ActorEntity Actor { get; set; }
        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
