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
        public virtual DbSet<ChevalCour> ChevalCours { get; set; }
        public virtual DbSet<Cour> Cours { get; set; }
        public virtual DbSet<Niveau> Niveaux { get; set; }
        public virtual DbSet<ProfCour> ProfCours { get; set; }
        public virtual DbSet<Professeur> Professeurs { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<TypeCour> TypeCours { get; set; }
    
        public virtual int AddCours(Nullable<System.DateTime> cours_debut, Nullable<System.DateTime> cours_fin, string typecours, string discipline, string niveau, Nullable<System.Guid> idProfesseur)
        {
            var cours_debutParameter = cours_debut.HasValue ?
                new ObjectParameter("cours_debut", cours_debut) :
                new ObjectParameter("cours_debut", typeof(System.DateTime));
    
            var cours_finParameter = cours_fin.HasValue ?
                new ObjectParameter("cours_fin", cours_fin) :
                new ObjectParameter("cours_fin", typeof(System.DateTime));
    
            var typecoursParameter = typecours != null ?
                new ObjectParameter("typecours", typecours) :
                new ObjectParameter("typecours", typeof(string));
    
            var disciplineParameter = discipline != null ?
                new ObjectParameter("discipline", discipline) :
                new ObjectParameter("discipline", typeof(string));
    
            var niveauParameter = niveau != null ?
                new ObjectParameter("niveau", niveau) :
                new ObjectParameter("niveau", typeof(string));
    
            var idProfesseurParameter = idProfesseur.HasValue ?
                new ObjectParameter("idProfesseur", idProfesseur) :
                new ObjectParameter("idProfesseur", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddCours", cours_debutParameter, cours_finParameter, typecoursParameter, disciplineParameter, niveauParameter, idProfesseurParameter);
        }
    
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
    
        public virtual ObjectResult<Nullable<System.Guid>> AjouterProfesseur(string prenom, string nom, ObjectParameter identity)
        {
            var prenomParameter = prenom != null ?
                new ObjectParameter("prenom", prenom) :
                new ObjectParameter("prenom", typeof(string));
    
            var nomParameter = nom != null ?
                new ObjectParameter("nom", nom) :
                new ObjectParameter("nom", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.Guid>>("AjouterProfesseur", prenomParameter, nomParameter, identity);
        }
    
        public virtual int AjouterProfesseurCours(Nullable<System.Guid> idProfesseur, string typeCours, string discipline, string niveau)
        {
            var idProfesseurParameter = idProfesseur.HasValue ?
                new ObjectParameter("idProfesseur", idProfesseur) :
                new ObjectParameter("idProfesseur", typeof(System.Guid));
    
            var typeCoursParameter = typeCours != null ?
                new ObjectParameter("typeCours", typeCours) :
                new ObjectParameter("typeCours", typeof(string));
    
            var disciplineParameter = discipline != null ?
                new ObjectParameter("discipline", discipline) :
                new ObjectParameter("discipline", typeof(string));
    
            var niveauParameter = niveau != null ?
                new ObjectParameter("niveau", niveau) :
                new ObjectParameter("niveau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AjouterProfesseurCours", idProfesseurParameter, typeCoursParameter, disciplineParameter, niveauParameter);
        }
    
        public virtual int DeleteCours(Nullable<System.Guid> idCours)
        {
            var idCoursParameter = idCours.HasValue ?
                new ObjectParameter("idCours", idCours) :
                new ObjectParameter("idCours", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteCours", idCoursParameter);
        }
    
        public virtual int DeleteReservation(Nullable<System.Guid> idRes)
        {
            var idResParameter = idRes.HasValue ?
                new ObjectParameter("idRes", idRes) :
                new ObjectParameter("idRes", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteReservation", idResParameter);
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
    
        public virtual ObjectResult<GetChevauxTable_Result> GetChevauxTable()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetChevauxTable_Result>("GetChevauxTable");
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
    
        public virtual ObjectResult<GetProfesseur_Result> GetProfesseur(string typecours, string niveau)
        {
            var typecoursParameter = typecours != null ?
                new ObjectParameter("typecours", typecours) :
                new ObjectParameter("typecours", typeof(string));
    
            var niveauParameter = niveau != null ?
                new ObjectParameter("niveau", niveau) :
                new ObjectParameter("niveau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProfesseur_Result>("GetProfesseur", typecoursParameter, niveauParameter);
        }
    
        public virtual ObjectResult<GetProfesseurTable_Result> GetProfesseurTable()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProfesseurTable_Result>("GetProfesseurTable");
        }
    
        public virtual ObjectResult<GetReservationUser_Result> GetReservationUser(string idUser)
        {
            var idUserParameter = idUser != null ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetReservationUser_Result>("GetReservationUser", idUserParameter);
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
    
        public virtual ObjectResult<GetParticipantsCours_Result> GetParticipantsCours(Nullable<System.Guid> idCours)
        {
            var idCoursParameter = idCours.HasValue ?
                new ObjectParameter("idCours", idCours) :
                new ObjectParameter("idCours", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetParticipantsCours_Result>("GetParticipantsCours", idCoursParameter);
        }
    }
}
