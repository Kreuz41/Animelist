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
    
    public partial class UsersFavoriteTitles
    {
        public int UserID { get; set; }
        public Nullable<int> TitleID { get; set; }
        public int ID { get; set; }
    
        public virtual Titles Titles { get; set; }
        public virtual Users Users { get; set; }
    }
}