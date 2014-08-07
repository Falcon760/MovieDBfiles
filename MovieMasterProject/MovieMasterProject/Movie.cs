
namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Movie
    {
        public Movie()
        {
            this.MovieRatings = new HashSet<MovieRating>();
            this.MovieActors = new HashSet<MovieActor>();
        }
    
        public int MovieId { get; set; }
        public string Title { get; set; }
        public Nullable<int> DirectorId { get; set; }
        public Nullable<int> GenreId { get; set; }
        public Nullable<decimal> Rating { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string Summary { get; set; }
    
        public virtual Director Director { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual MessageBoard MessageBoard { get; set; }
        public virtual ICollection<MovieRating> MovieRatings { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }
}
