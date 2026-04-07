using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_EfCodeFirstMovie.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [StringLength(100)]
        public string MovieTitle { get; set; }

        public string MovieDescription { get; set; }
        public int MovieDuration { get; set; }
        public DateTime MovieReleaseDate { get; set; }
        public bool MovieStatus { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
