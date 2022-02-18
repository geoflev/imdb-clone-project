using IMDBClone.Persistence.Entities;

namespace imdb_clone_models.Entities
{
    public class ProducerMoviesEntity
    {
        public int ProducerId { get; set; }
        public ProducerEntity Producer { get; set; }
        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
