//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sifaeczadeposu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class fuarkayit
    {
        public int ID { get; set; }
        public int FKuyeID { get; set; }
        public int FKfuarID { get; set; }
        public string k_ad { get; set; }
        public string sifre { get; set; }
    
        public virtual fuar fuar { get; set; }
        public virtual uye uye { get; set; }
    }
}
