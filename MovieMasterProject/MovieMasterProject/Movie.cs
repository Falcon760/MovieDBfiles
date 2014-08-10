
namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Movie
    {
        public Movie()
        {
            this.MovieActors = new HashSet<MovieActor>();
            this.Ratings = new HashSet<Rating>();
        }
    
        public int MovieId { get; set; }
        public string Title { get; set; }
        public Nullable<int> DirectorId { get; set; }
        public Nullable<int> GenreId { get; set; }
        [DisplayName("Total Rating")]
        public Nullable<decimal> Rating { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string Summary { get; set; }
    
        public virtual Director Director { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual MessageBoard MessageBoard { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
