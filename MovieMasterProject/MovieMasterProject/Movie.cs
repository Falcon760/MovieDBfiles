//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    
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
        public Nullable<decimal> Rating { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string Summary { get; set; }
        public byte[] Picture { get; set; }
        public string ImagePath { get; set; }
    
        public virtual Director Director { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual MessageBoard MessageBoard { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
