//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nhóm4_SHOOS_Shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class THE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THE()
        {
            this.KHACHHANGs = new HashSet<KHACHHANG>();
        }
    
        public int MATHE { get; set; }
        public string SOTHE { get; set; }
        public string TENNGANHANG { get; set; }
        public string CHUTAIKHOAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACHHANG> KHACHHANGs { get; set; }
    }
}
