//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int Id { get; set; }
        public string Название { get; set; }
        public string Краткое_описание { get; set; }
        public string Обложка { get; set; }
        public string Жанр { get; set; }
        public string Автор { get; set; }
        public string Путь_к_Файлу { get; set; }
    }
}