//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class MessageBoardA
    {
        public MessageBoardA()
        {
            this.CommentAs = new HashSet<CommentA>();
        }
    
        public int MessageBoardId { get; set; }
        public string MessageBoardName { get; set; }
    
        public virtual Actor Actor { get; set; }
        public virtual ICollection<CommentA> CommentAs { get; set; }
    }
}
