using imdb_clone_models.Entities;
using System.Collections.Generic;

namespace IMDBClone.Persistence.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCategoriesEntity> Movies { get; set; }
    }
}
