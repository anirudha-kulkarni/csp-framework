using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPLibrary
{
    public class NewCustomerVendorModel
    {
        [Required]
        [Display(Name = "Customer-Vendor Id")]
        public int Customer_Vendor_Id { get; set; }

        [Required]
        [Display(Name = "Vendor Id")]
        public int? Vendor_Id { get; set; }

        [Required]
        [Display(Name = "Vendor Name")]      
        public string VendorName { get; set; }

        [Display(Name = "Account Number")]       
        public string Account { get; set; }

        [Required]
        [Display(Name = "Function")]
        public int? Function { get; set; }

        public string FunctionString { get; set; }

        [Required]
        [Display(Name = "Function Notes")]
        public string FunctionNotes { get; set; }

        [Required]
        [Display(Name = "Level 1 UserName")]
        public string L1UserName { get; set; }

        [Required]
        [Display(Name = "Level 1 Password")]
        public string L1Password { get; set; }

        [Display(Name = "Level 2 UserName")]
        public string L2UserName { get; set; }

        [Display(Name = "Level 2 Password")]
        public string L2Password { get; set; }

        [Display(Name = "Agreement File")]
        public string AgreementPath { get; set; }
                
        [Display(Name = "Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime? AgreementStartDate { get; set; }

        
        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        public DateTime? AgreementEndDate { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int? Status { get; set; }

        public string StatusString { get; set; }

        [Required]
        [Display(Name = "Client Id")]
        public int? Client_Id { get; set; }

        [Required]
        [Display(Name = "Client Code")]
        public String ClientCode { get; set; }

        [Display(Name = "Site")]
        public int? Site { get; set; }

        public String SolutionString { get; set; }
    }

   public class CustomerVendorViewModel
    {
        public IEnumerable<CSPLibrary.NewCustomerVendorModel> RegisteredCustomerVendorList { get; set; }        
    }

    public class CustomerVendorViewModelPost
    {
        public NewCustomerVendorModel newCustomerVendorModel { get; set; }
        
        public Object iFunction { get; set; } 
        //public ISP isp { get; set; } 
    }
    
}
