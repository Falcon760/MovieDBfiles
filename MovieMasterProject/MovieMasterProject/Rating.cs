
namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Rating
    {
        public int RatingId { get; set; }
        public string UserName { get; set; }
        public Nullable<int> MovieId { get; set; }
        [Range(0,5, ErrorMessage="Value must be between 0 and 5.")]
        public Nullable<decimal> Value { get; set; }
    
        public virtual Movie Movie { get; set; }
    }
}
