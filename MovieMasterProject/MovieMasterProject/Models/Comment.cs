using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieMasterProject
{

    [MetadataType(typeof(CommentMetaData))]
    public partial class Comment
    {


        public partial class CommentMetaData
        {

            [DisplayName("Contents")]
            [MaxLength(500,ErrorMessage="Your comment cannot excede 500 characters.")]
            public string CommentContents { get; set; }


        }
    }
}