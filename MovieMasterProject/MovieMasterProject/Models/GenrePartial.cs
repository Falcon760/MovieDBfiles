using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMasterProject.Models
{
    [MetadataType(typeof(GenreMetaData))]
    public partial class Genre
    {
        public class GenreMetaData
        {
            [DisplayName("Genre Type")]
            public string GenreType { get; set; }

        }

    }
}