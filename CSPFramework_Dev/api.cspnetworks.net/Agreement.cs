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
    
    public partial class Agreement
    {
        public Agreement()
        {
            this.Clients = new HashSet<Client>();
            this.Customer_Vendors = new HashSet<Customer_Vendors>();
        }
    
        public int agreement_id { get; set; }
        public string filepath { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
    
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Customer_Vendors> Customer_Vendors { get; set; }
    }
}
