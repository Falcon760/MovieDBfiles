using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMasterProject
{
    [MetadataType(typeof(ActorMetaData))]
    public partial class Actor
    {

        public class ActorMetaData
        {
            [Required]
            [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "Invalid First Name")]
            [DisplayName("First Name")]
            public string FirstName { get; set; }
            [Required]
            [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "Invalid Last Name")]
            [DisplayName("Last Name")]
            public string LastName { get; set; }
            [DisplayName("Date of Birth")]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            public string DateOfBirth { get; set; }

        }
    }
}