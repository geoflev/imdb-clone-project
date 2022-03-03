using GMDB.Persistence.Entities;

namespace GMDB.Persistence.Entities
{
    public class MovieCategoriesEntity
    {
        public string CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public string MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
