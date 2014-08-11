
namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        [DisplayName("Contents")]
        public string CommentContents { get; set; }
        public Nullable<int> MessageBoardId { get; set; }
    
        public virtual MessageBoard MessageBoard { get; set; }
    }
}
