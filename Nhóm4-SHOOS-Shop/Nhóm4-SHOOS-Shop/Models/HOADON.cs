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
    
    public partial class HOADON
    {
        public int MAHD { get; set; }
        public Nullable<int> MANV { get; set; }
        public Nullable<System.DateTime> NGAYLAPHD { get; set; }
    
        public virtual DATHANG DATHANG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
