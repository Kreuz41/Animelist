//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Animelist.Models.Baza
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Users_PlannedTitles = new HashSet<Users_PlannedTitles>();
            this.UsersFavoriteTitles = new HashSet<UsersFavoriteTitles>();
        }
    
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public Nullable<int> FavoriteAnimeID { get; set; }
        public Nullable<int> PlannedAnimeID { get; set; }
        public string UserRights { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_PlannedTitles> Users_PlannedTitles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersFavoriteTitles> UsersFavoriteTitles { get; set; }
    }
}