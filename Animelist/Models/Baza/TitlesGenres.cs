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
    
    public partial class TitlesGenres
    {
        public int TitleID { get; set; }
        public int GenreID { get; set; }
        public int ID { get; set; }
    
        public virtual Genres Genres { get; set; }
        public virtual Titles Titles { get; set; }
    }
}