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
    
    public partial class Enum_Type_Values
    {
        public Enum_Type_Values()
        {
            this.Clients = new HashSet<Client>();
            this.Clients1 = new HashSet<Client>();
            this.Clients2 = new HashSet<Client>();
            this.Customer_Vendors = new HashSet<Customer_Vendors>();
            this.Customer_Vendors1 = new HashSet<Customer_Vendors>();
            this.Hardwares = new HashSet<Hardware>();
            this.Hardwares1 = new HashSet<Hardware>();
            this.Hardwares2 = new HashSet<Hardware>();
            this.Hardwares3 = new HashSet<Hardware>();
<<<<<<< HEAD
            this.Softwares = new HashSet<Software>();
            this.Softwares1 = new HashSet<Software>();
            this.Softwares2 = new HashSet<Software>();
            this.Softwares3 = new HashSet<Software>();
            this.Softwares4 = new HashSet<Software>();
=======
>>>>>>> cbe8ccf... 1. Changes merged for adding billing section in the client's Add new, Edit details and display client details
            this.Users = new HashSet<User>();
        }
    
        public int enum_type_value_id { get; set; }
        public int enum_type_id { get; set; }
        public string enum_type_value { get; set; }
    
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Client> Clients1 { get; set; }
        public virtual ICollection<Client> Clients2 { get; set; }
        public virtual ICollection<Customer_Vendors> Customer_Vendors { get; set; }
        public virtual ICollection<Customer_Vendors> Customer_Vendors1 { get; set; }
        public virtual Enum_Types Enum_Types { get; set; }
        public virtual ICollection<Hardware> Hardwares { get; set; }
        public virtual ICollection<Hardware> Hardwares1 { get; set; }
        public virtual ICollection<Hardware> Hardwares2 { get; set; }
        public virtual ICollection<Hardware> Hardwares3 { get; set; }
<<<<<<< HEAD
        public virtual ICollection<Software> Softwares { get; set; }
        public virtual ICollection<Software> Softwares1 { get; set; }
        public virtual ICollection<Software> Softwares2 { get; set; }
        public virtual ICollection<Software> Softwares3 { get; set; }
        public virtual ICollection<Software> Softwares4 { get; set; }
=======
>>>>>>> cbe8ccf... 1. Changes merged for adding billing section in the client's Add new, Edit details and display client details
        public virtual ICollection<User> Users { get; set; }
    }
}
