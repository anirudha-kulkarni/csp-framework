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
    
    public partial class Client
    {
        public Client()
        {
            this.Customer_Vendors = new HashSet<Customer_Vendors>();
            this.Users = new HashSet<User>();
        }
    
        public int client_id { get; set; }
        public string client_code { get; set; }
        public string company_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string website { get; set; }
        public Nullable<int> service_type { get; set; }
        public Nullable<int> agreement_id { get; set; }
        public Nullable<int> team { get; set; }
        public Nullable<int> status { get; set; }
        public string sites { get; set; }
    
        public virtual Agreement Agreement { get; set; }
        public virtual Enum_Type_Values ServiceType_Enum_Type_Values { get; set; }
        public virtual Enum_Type_Values Status_Enum_Type_Values { get; set; }
        public virtual Enum_Type_Values Team_Enum_Type_Values { get; set; }
        public virtual ICollection<Customer_Vendors> Customer_Vendors { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
