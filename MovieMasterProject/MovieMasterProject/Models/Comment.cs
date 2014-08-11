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
            public string CommentContents { get; set; }


        }
    }
}