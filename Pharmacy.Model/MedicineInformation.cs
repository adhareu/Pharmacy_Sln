//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pharmacy.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicineInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedicineInformation()
        {
            this.SalesInformationDetails = new HashSet<SalesInformationDetails>();
        }
    
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public decimal Price { get; set; }
        public int UnitTypeID { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual UnitType UnitType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesInformationDetails> SalesInformationDetails { get; set; }
    }
}
