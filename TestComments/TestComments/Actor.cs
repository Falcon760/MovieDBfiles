//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestComments
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
        }
    
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Bio { get; set; }
    
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual MessageBoard MessageBoard { get; set; }
    }
}
