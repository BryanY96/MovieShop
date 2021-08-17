using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {
        // foreign key
        public int MovieId { get; set; }
        // foreign key
        public int CastId { get; set; }
        public string Character { get; set; }

        // Navigation properties
        public Movie Movie { get; set; }
        public Cast Cast { get; set; }

    }
}
