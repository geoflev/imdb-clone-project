using System;
using System.Collections.Generic;

namespace GMDB.Persistence.Entities
{
    public class MovieEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public double Budget { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string[] ExternalIds { get; set; }
        public ICollection<MovieEntity> RelatedMovies { get; set; }
        public ICollection<MovieCategoriesEntity> Categories { get; set; }
        public ICollection<ActorMoviesEntity> Actors { get; set; }
        public ICollection<ProducerMoviesEntity> Producers { get; set; }
        public ICollection<FileEntity> Posters { get; set; }
        public ICollection<FileEntity> Backdrops { get; set; }
        public ICollection<FileEntity> Videos { get; set; }
    }
}
