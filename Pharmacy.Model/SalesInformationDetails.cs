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
    
    public partial class SalesInformationDetails
    {
        public int SalesDetailsID { get; set; }
        public int SalesID { get; set; }
        public int MedicineID { get; set; }
        public int TotalUnit { get; set; }
        public int TotalCost { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual MedicineInformation MedicineInformation { get; set; }
        public virtual SalesInformation SalesInformation { get; set; }
    }
}
