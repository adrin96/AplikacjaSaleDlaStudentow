//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektSale
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRACOWNICY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRACOWNICY()
        {
            this.PRACOWNICY1 = new HashSet<PRACOWNICY>();
            this.REZERWACJE = new HashSet<REZERWACJE>();
        }
    
        public int ID_PRACOWNIKA { get; set; }
        public string IMIE { get; set; }
        public string NAZWISKO { get; set; }
        public float PENSJA { get; set; }
        public Nullable<System.DateTime> DATA_ZATRUDNIENIA { get; set; }
        public int ID_BIURA { get; set; }
        public Nullable<int> ID_PRZELOZONEGO { get; set; }
        public string STANOWISKO { get; set; }
    
        public virtual BIURA BIURA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRACOWNICY> PRACOWNICY1 { get; set; }
        public virtual PRACOWNICY PRACOWNICY2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REZERWACJE> REZERWACJE { get; set; }
    }
}