using IMDBClone.Persistence.Entities;

namespace imdb_clone_models.Entities
{
    public class MovieCategoriesEntity
    {
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
