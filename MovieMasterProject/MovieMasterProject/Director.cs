
namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Director
    {
        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }
    
        public int DirectorId { get; set; }
        [DisplayName("Director Name")]
        public string DirectorName { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }
        public string Bio { get; set; }
    
        public virtual MessageBoardD MessageBoardD { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
