//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medication()
        {
            this.Treatments = new HashSet<Treatment>();
        }
    
        public int MedicationID { get; set; }
        public string Description { get; set; }
        public Nullable<int> MT_ID { get; set; }
        public Nullable<int> IllnessTypeID { get; set; }
    
        public virtual IllnessType IllnessType { get; set; }
        public virtual MedicationType MedicationType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}