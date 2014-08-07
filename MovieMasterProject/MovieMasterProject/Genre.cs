
namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Genre
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
    
        public int GenreId { get; set; }
        [DisplayName("Genre Type")]
        public string GenreType { get; set; }
    
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
