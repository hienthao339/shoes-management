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
    
    public partial class GIAOHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAOHANG()
        {
            this.DATHANGs = new HashSet<DATHANG>();
        }
    
        public int MAGH { get; set; }
        public Nullable<int> MATX { get; set; }
        public Nullable<System.DateTime> NGAYGIAO { get; set; }
        public Nullable<System.DateTime> NGAYHOANTHANH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATHANG> DATHANGs { get; set; }
        public virtual TAIXE TAIXE { get; set; }
    }
}
