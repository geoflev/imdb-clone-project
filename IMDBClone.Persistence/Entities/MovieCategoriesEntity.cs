using IMDBClone.Persistence.Entities;

namespace imdb_clone_models.Entities
{
    public class MovieCategoriesEntity
    {
        public string CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public string MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
