using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CSPLibrary
{
    
    public class Fun_Application
    {
        [Display(Name = "Solution")]
        public String App_Solution { get; set; }

        [Display(Name = "IP Address")]
        public String App_IP_Address { get; set; }

        [Display(Name = "Login URL")]
        public String App_Login_Url { get; set; }

        [Display(Name = "Management URL")]
        public String App_Management_Url { get; set; }       
    }

    public class Fun_Fax
    {

        [Display(Name = "Solution")]
        public String Fax_Solution { get; set; }

        [Display(Name = "Fax Number")]
        public String Fax_Number { get; set; }

        
        [Display(Name = "Management URL")]
        public String Fax_Management_Url { get; set; }  
    }

    public class Fun_Phone_System
    {
        [Display(Name = "Solution")]
        public String Phone_Sys_Solution { get; set; }

        [Display(Name = "IP Address")]
        public String Phone_Sys_IP_Address { get; set; }

       [Display(Name = "Management URL")]
        public String Phone_Sys_Management_Url { get; set; }  
    }

    public class Fun_Connectivity_Phone
    {
        [Display(Name = "Solution")]
        public String Conn_Phone_Solution { get; set; }

        [Display(Name = "Phone Number")]
        public String Conn_Phone_Phone_Number { get; set; }

        [Display(Name = "Management URL")]
        public String Conn_Phone_Management_Url { get; set; }  
    }

    public class Fun_Cloud
    {
        [Display(Name = "Solution")]
        public String Cloud_Solution { get; set; }

        [Display(Name = "IP Address")]
        public String Cloud_IP_Address { get; set; }

        [Display(Name = "Management URL")]
        public String Cloud_Management_Url { get; set; }  
    }

    public class Fun_Connectivity_Internet
    {
        [Display(Name = "Solution")]
        public String Conn_Int_Solution { get; set; }

        [Display(Name = "Connectivity")]
        public String Conn_Int_Connectivity { get; set; }

        [Display(Name = "WAN IP Address")]
        public String Conn_Int_Wan_IP_Address { get; set; }

        [Display(Name = "Subnet Mask")]
        public String Conn_Int_SubnetMask { get; set; }

        [Display(Name = "DNS1")]
        public String Conn_Int_DNS1 { get; set; }

        [Display(Name = "DNS2")]
        public String Conn_Int_DNS2 { get; set; }

        [Display(Name = "Available WAN Ips")]
        public String Conn_Int_Wan_IPs { get; set; }

        [Display(Name = "Management URL")]
        public String Conn_Int_Management_Url { get; set; }  

    }

    public class Fun_Printer
    {
        [Display(Name = "Solution")]
        public String Printer_Solution { get; set; }

        [Display(Name = "IP Address")]
        public String Printer_IP_Address { get; set; }

        [Display(Name = "Management URL")]
        public String Printer_Management_Url { get; set; }  
    }
}
