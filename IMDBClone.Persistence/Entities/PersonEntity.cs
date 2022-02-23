﻿using imdb_clone_models.Entities.Enums;
using System;
using System.Collections.Generic;

namespace IMDBClone.Persistence.Entities
{
    public abstract class PersonEntity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Bio { get; set; }
        public ICollection<FileEntity> Images { get; set; }
    }
}
