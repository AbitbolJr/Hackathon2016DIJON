//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCK_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profil()
        {
            this.Utilisateurs = new HashSet<Utilisateur>();
        }
    
        public int idProfil { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public string dateDeNaissance { get; set; }
        public string fonction { get; set; }
        public string entreprise { get; set; }
        public string descriptionPro { get; set; }
        public string descriptionLoisir { get; set; }
        public Nullable<bool> actifLoisir { get; set; }
        public Nullable<bool> actifPro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}