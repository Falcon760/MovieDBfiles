
namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class MessageBoard
    {
        public MessageBoard()
        {
            this.Comments = new HashSet<Comment>();
            this.Reviews = new HashSet<Review>();
        }
    
        public int MessageBoardId { get; set; }
        [DisplayName("Message Board Name")]
        public string MessageBoardName { get; set; }
    
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Movie Movie { get; set; }
        
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
