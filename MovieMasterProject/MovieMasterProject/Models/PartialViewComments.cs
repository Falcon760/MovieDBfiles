using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieMasterProject.Models
{
    public partial class PartialViewComments
    {
        public string Name { get; set; }
        public string Comment { get; set; }
    }
    public partial class PartialViewComments
    {
        public List<PartialViewComments> partialComments { get; set; }
    }
}