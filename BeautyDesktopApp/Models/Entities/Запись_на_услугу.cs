//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeautyDesktopApp.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Запись_на_услугу
    {
        public int ID_записи_на_услугу { get; set; }
        public int ID_услуги { get; set; }
        public int ID_клиента { get; set; }
        public System.DateTime Дата_начала { get; set; }
        public System.DateTime Время_начала { get; set; }
        public string Номер_карты { get; set; }
    
        public virtual Клиент Клиент { get; set; }
        public virtual Услуга Услуга { get; set; }
    }
}
