//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProfCour
    {
        public System.Guid PROFCOURS_ID { get; set; }
        public System.Guid PROFESSEUR_ID { get; set; }
        public System.Guid TYPECOURS_ID { get; set; }
        public System.Guid NIVEAU_ID { get; set; }
    
        public virtual Niveau Niveau { get; set; }
        public virtual Professeur Professeur { get; set; }
        public virtual TypeCour TypeCour { get; set; }
    }
}
