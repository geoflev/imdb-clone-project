using IMDBClone.Persistence.Entities;
using System.Collections.Generic;

namespace imdb_clone_models.Entities
{
    public class ProducerEntity : PersonEntity
    {
        public int ProducerScore { get; set; }
        public ICollection<ProducerMoviesEntity> Movies { get; set; }
    }
}
