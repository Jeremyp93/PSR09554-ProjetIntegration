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
    
    public partial class Cour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cour()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public System.Guid COURS_id { get; set; }
        public System.DateTime COURS_debut { get; set; }
        public System.DateTime COURS_fin { get; set; }
        public int COURS_NombreDePlaces { get; set; }
        public System.Guid TYPECOURS_id { get; set; }
        public System.Guid NIVEAU_id { get; set; }
        public System.Guid PROFESSEUR_id { get; set; }
    
        public virtual Niveau Niveau { get; set; }
        public virtual Professeur Professeur { get; set; }
        public virtual TypeCour TypeCour { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
