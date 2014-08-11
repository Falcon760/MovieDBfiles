using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMasterProject
{
    [MetadataType(typeof(DirectorMetaData))]
    public partial class Director
    {

        public class DirectorMetaData
        {
            [DisplayName("Director Name")]
            public string DirectorName { get; set; }
            [DisplayName("Birth Date")]
            [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
            public string DateOfBirth { get; set; }

        }
    }
}