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
    
    public partial class User
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
        public string user_group { get; set; }
        public Nullable<int> client_id { get; set; }
        public string security_question_one { get; set; }
        public string security_question_two { get; set; }
        public string security_answer_one { get; set; }
        public string security_answer_two { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> creation_date { get; set; }
        public string name { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Enum_Type_Values Status_Enum_Type_Values { get; set; }
        public virtual User_Groups User_Groups { get; set; }
    }
}
