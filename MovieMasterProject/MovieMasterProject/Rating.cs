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
    using System.ComponentModel;
    
    public partial class Rating
    {
        public Rating()
        {
            this.MovieRatings = new HashSet<MovieRating>();
        }
    
        public int RatingId { get; set; }
        [DisplayName("Rating")]
        public Nullable<decimal> RatingValue { get; set; }
    
        public virtual ICollection<MovieRating> MovieRatings { get; set; }
    }
}
