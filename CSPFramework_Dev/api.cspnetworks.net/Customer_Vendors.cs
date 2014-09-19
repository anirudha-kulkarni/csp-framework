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
    
    public partial class Customer_Vendors
    {
        public int customer_vendor_id { get; set; }
        public Nullable<int> vendor_id { get; set; }
        public string account_number { get; set; }
        public Nullable<int> function_name { get; set; }
        public Nullable<int> FunctionNotes_Id { get; set; }
        public string username_L1 { get; set; }
        public string password_L1 { get; set; }
        public Nullable<int> agreement_id { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> client_id { get; set; }
        public string site { get; set; }
        public string username_L2 { get; set; }
        public string password_L2 { get; set; }
    
        public virtual Agreement Agreement { get; set; }
        public virtual Client Client { get; set; }
        public virtual Enum_Type_Values FunctionName_Enum_Type_Values { get; set; }
        public virtual Function_Notes Function_Notes { get; set; }
        public virtual Enum_Type_Values Status_Enum_Type_Values { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
