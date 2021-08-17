using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Review
    {
        // Foreign Keys:
        public int MovieId { get; set; }
        public int UserId { get; set; }

        // own properties
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }

        // navigation:
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
