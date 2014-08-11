using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMasterProject
{
    [MetadataType(typeof(RatingMetaData))]
    public partial class Rating
    {

        public class RatingMetaData
        {
            [DisplayName("Rating")]
            [Range(0, 5, ErrorMessage = "Value must be between 0 and 5.")]
            public Nullable<decimal> Value { get; set; }

        }
    }
}