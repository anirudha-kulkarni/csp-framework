//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api.cspnetworks.net
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vendor
    {
        public Vendor()
        {
            this.Customer_Vendors = new HashSet<Customer_Vendors>();
            this.Hardwares = new HashSet<Hardware>();
        }
    
        public int vendor_id { get; set; }
        public string name { get; set; }
        public string support_number { get; set; }
        public string support_email { get; set; }
        public string website { get; set; }
    
        public virtual ICollection<Customer_Vendors> Customer_Vendors { get; set; }
        public virtual ICollection<Hardware> Hardwares { get; set; }
    }
}
