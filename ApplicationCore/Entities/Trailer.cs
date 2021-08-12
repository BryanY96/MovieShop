﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    // 56 => name of trailer, url, title, revenue
    public class Trailer
    {
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int MovieId { get; set; }

        // Navigation Property
        public Movie Movie { get; set; }

    }
}
