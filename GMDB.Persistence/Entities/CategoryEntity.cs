using System.Collections.Generic;

namespace GMDB.Persistence.Entities
{
    public class CategoryEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCategoriesEntity> Movies { get; set; }
    }
}
