using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieMasterProject.Models
{
    public class RatingsModel
    {
            public RatingsModel()
            {
                RatingsList = new List<SelectListItem>();
            }
            [Display(Name = "Ratings")]
            public int RatingId { get; set; }
            public IEnumerable<SelectListItem> RatingsList { get; set; }
        }





    }