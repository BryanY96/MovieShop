using System;
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

        // Foreign Key -- divide the property (MovieId) into two parts: Movie & Id
        public int MovieId { get; set; }

        // Navigation Property -- Like a join table
        public Movie Movie { get; set; }

    }
}
