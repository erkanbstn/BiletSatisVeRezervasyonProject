//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiletSatisVeRezervasyonProject.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBilet
    {
        public int BiletID { get; set; }
        public string No { get; set; }
        public string Kisi { get; set; }
        public string Telefon { get; set; }
        public Nullable<int> Otobus { get; set; }
        public string Koltuk { get; set; }
        public string Guzergah { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Durum { get; set; }
        public Nullable<int> Fiyat { get; set; }
        public string Cinsiyet { get; set; }
    
        public virtual TOtobus TOtobus { get; set; }
    }
}