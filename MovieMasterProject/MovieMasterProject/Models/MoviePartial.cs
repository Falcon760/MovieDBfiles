using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieMasterProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMasterProject

{
    [MetadataType(typeof(MovieMetaData))]
    public partial class Movie
    {
        public class MovieMetaData
        {

            [DisplayName("Total Rating")]
            public Nullable<decimal> Rating { get; set; }
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            public Nullable<System.DateTime> ReleaseDate { get; set; }
            [Column(TypeName = "image")]
            public byte[] Picture { get; set; } //needed for database
            public string ImagePath { get; set; } //needed for server



        }

    }
}