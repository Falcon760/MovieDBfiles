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
    
    public partial class MovieActor
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public int Id { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
