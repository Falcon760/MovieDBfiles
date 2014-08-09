//------------------------------------------------------------------------------
// <auto-generated>

namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Review
    {
        public int ReviewId { get; set; }
        public string UserName { get; set; }
        [DisplayName("Title")]
        public string ReviewTitle { get; set; }
        [Range(0, 5, ErrorMessage = "Value must be between 0 and 5.")]
        public Nullable<decimal> Rating { get; set; }
        public Nullable<int> MessageBoardId { get; set; }
        public string ReviewContents { get; set; }
    
        public virtual MessageBoard MessageBoard { get; set; }
    }
}
