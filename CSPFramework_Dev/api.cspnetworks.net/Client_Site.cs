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
    
    public partial class Client_Site
    {
        public Client_Site()
        {
            this.Customer_Vendors = new HashSet<Customer_Vendors>();
            this.Hardwares = new HashSet<Hardware>();
            this.Softwares = new HashSet<Software>();
        }
    
        public int client_site_id { get; set; }
        public int client_id { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string site_name { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ICollection<Customer_Vendors> Customer_Vendors { get; set; }
        public virtual ICollection<Hardware> Hardwares { get; set; }
        public virtual ICollection<Software> Softwares { get; set; }
    }
}
