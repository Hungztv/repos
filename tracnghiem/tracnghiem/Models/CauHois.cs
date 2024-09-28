//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tracnghiem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CauHois
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CauHois()
        {
            this.KetQuas = new HashSet<KetQua>();
        }
    
        public long id { get; set; }
        public string Cauhoi { get; set; }
        public string dap_an_a { get; set; }
        public string dap_an_b { get; set; }
        public string dap_an_c { get; set; }
        public string dap_an_d { get; set; }
        public Nullable<int> MaDapAn { get; set; }
        public string ghi_chu { get; set; }
        public Nullable<int> MaMonHoc { get; set; }
        public Nullable<int> MaMucDo { get; set; }
    
        public virtual DapAn DapAn { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual MucDoKho MucDoKho { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
