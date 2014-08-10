
namespace MovieMasterProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Actor
    {
        public Actor()
        {
            this.MovieActors = new HashSet<MovieActor>();
        }

        public int ActorId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string DateOfBirth { get; set; }
        public string Bio { get; set; }
    
        public virtual MessageBoardA MessageBoardA { get; set; }
        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }
}
