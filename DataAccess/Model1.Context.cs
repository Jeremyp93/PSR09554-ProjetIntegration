﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ExamenProjetIntegrationEntities : DbContext
    {
        public ExamenProjetIntegrationEntities()
            : base("name=ExamenProjetIntegrationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Cheval> Chevals { get; set; }
        public virtual DbSet<Cour> Cours { get; set; }
        public virtual DbSet<Niveau> Niveaux { get; set; }
        public virtual DbSet<Professeur> Professeurs { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<TypeCour> TypeCours { get; set; }
    
        public virtual int AddReservation(Nullable<System.Guid> idUser, Nullable<System.Guid> idCours, Nullable<System.Guid> idCheval)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(System.Guid));
    
            var idCoursParameter = idCours.HasValue ?
                new ObjectParameter("idCours", idCours) :
                new ObjectParameter("idCours", typeof(System.Guid));
    
            var idChevalParameter = idCheval.HasValue ?
                new ObjectParameter("idCheval", idCheval) :
                new ObjectParameter("idCheval", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddReservation", idUserParameter, idCoursParameter, idChevalParameter);
        }
    
        public virtual ObjectResult<GetAllCours_Result> GetAllCours()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllCours_Result>("GetAllCours");
        }
    
        public virtual ObjectResult<GetChevauxFiltre_Result> GetChevauxFiltre(string typecours, string typediscipline, string niveau, Nullable<System.Guid> idCours)
        {
            var typecoursParameter = typecours != null ?
                new ObjectParameter("typecours", typecours) :
                new ObjectParameter("typecours", typeof(string));
    
            var typedisciplineParameter = typediscipline != null ?
                new ObjectParameter("typediscipline", typediscipline) :
                new ObjectParameter("typediscipline", typeof(string));
    
            var niveauParameter = niveau != null ?
                new ObjectParameter("niveau", niveau) :
                new ObjectParameter("niveau", typeof(string));
    
            var idCoursParameter = idCours.HasValue ?
                new ObjectParameter("idCours", idCours) :
                new ObjectParameter("idCours", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetChevauxFiltre_Result>("GetChevauxFiltre", typecoursParameter, typedisciplineParameter, niveauParameter, idCoursParameter);
        }
    
        public virtual ObjectResult<GetFiltre_Result> GetFiltre(string typecours, string typediscipline, string niveau, Nullable<System.DateTime> date, string user)
        {
            var typecoursParameter = typecours != null ?
                new ObjectParameter("typecours", typecours) :
                new ObjectParameter("typecours", typeof(string));
    
            var typedisciplineParameter = typediscipline != null ?
                new ObjectParameter("typediscipline", typediscipline) :
                new ObjectParameter("typediscipline", typeof(string));
    
            var niveauParameter = niveau != null ?
                new ObjectParameter("niveau", niveau) :
                new ObjectParameter("niveau", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFiltre_Result>("GetFiltre", typecoursParameter, typedisciplineParameter, niveauParameter, dateParameter, userParameter);
        }
    
        public virtual ObjectResult<GetFiltreDetail_Result> GetFiltreDetail(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFiltreDetail_Result>("GetFiltreDetail", idParameter);
        }
    
        public virtual ObjectResult<GetUser_Result> GetUser(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUser_Result>("GetUser", nameParameter);
        }
    
        public virtual int UpdateCoursParticipant(Nullable<System.Guid> idCours)
        {
            var idCoursParameter = idCours.HasValue ?
                new ObjectParameter("idCours", idCours) :
                new ObjectParameter("idCours", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateCoursParticipant", idCoursParameter);
        }
    }
}
