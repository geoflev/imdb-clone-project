using System.Collections.Generic;

namespace GMDB.Persistence.Entities
{
    public class ProducerEntity : PersonEntity
    {
        public int ProducerScore { get; set; }
        public ICollection<ProducerMoviesEntity> Movies { get; set; }
    }
}
