//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestComments
{
    using System;
    using System.Collections.Generic;
    
    public partial class MovieRating
    {
        public int MovieId { get; set; }
        public int RatingId { get; set; }
        public int UserId { get; set; }
    
        public virtual Movie Movie { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
