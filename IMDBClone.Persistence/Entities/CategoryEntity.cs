using imdb_clone_models.Entities;
using System.Collections.Generic;

namespace IMDBClone.Persistence.Entities
{
    public class CategoryEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCategoriesEntity> Movies { get; set; }
    }
}
