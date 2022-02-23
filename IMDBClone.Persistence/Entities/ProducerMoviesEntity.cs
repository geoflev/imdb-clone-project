﻿using IMDBClone.Persistence.Entities;

namespace imdb_clone_models.Entities
{
    public class ProducerMoviesEntity
    {
        public string ProducerId { get; set; }
        public ProducerEntity Producer { get; set; }
        public string MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
