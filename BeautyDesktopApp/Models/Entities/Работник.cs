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
    
    public partial class Работник
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Работник()
        {
            this.Запись_на_услугу = new HashSet<Запись_на_услугу>();
        }
    
        public int ID_раб { get; set; }
        public string ФИО { get; set; }
        public System.DateTime День_рождение { get; set; }
        public int Номер_телефона { get; set; }
        public int Стаж_работы { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
    
        public virtual Должность Должность { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Запись_на_услугу> Запись_на_услугу { get; set; }
    }
}
