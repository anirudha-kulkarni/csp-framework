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
    
    public partial class Enum_Types
    {
        public Enum_Types()
        {
            this.Enum_Type_Values = new HashSet<Enum_Type_Values>();
        }
    
        public int enum_type_id { get; set; }
        public string enum_type_name { get; set; }
    
        public virtual ICollection<Enum_Type_Values> Enum_Type_Values { get; set; }
    }
}
