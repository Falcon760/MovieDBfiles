using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMasterProject
{
    [MetadataType(typeof(ReviewMetaData))]
    public partial class Review
    {

        public class ReviewMetaData
        {
            [DisplayName("Review Title")]
            public string ReviewTitle { get; set; }
            [Range(0, 5, ErrorMessage = "Value must be between 0 and 5.")]
            public Nullable<decimal> Rating { get; set; }
            [DisplayName("Message Board Name")]
            public Nullable<int> MessageBoardId { get; set; }
            [MaxLength(5000,ErrorMessage="Your comment cannot excede 5000 characters.")]
            public string ReviewContents { get; set; }



        }
    }
}