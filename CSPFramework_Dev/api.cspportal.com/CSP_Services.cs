//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api.cspportal.com
{
    using System;
    using System.Collections.Generic;
    
    public partial class CSP_Services
    {
        public CSP_Services()
        {
            this.Clients = new HashSet<Client>();
        }
    
        public string service_type { get; set; }
    
        public virtual ICollection<Client> Clients { get; set; }
    }
}
