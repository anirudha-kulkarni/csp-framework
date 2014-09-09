using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CSPLibrary
{
    public class VendorsViewModel
    {
        public IEnumerable<CSPLibrary.NewVendorModel> RegisteredVendorsList { get; set; }
        public NewVendorModel NewVendorRegistrationModel { get; set; }
    }

   public class NewVendorModel
    {
        [Required]
        [Display(Name = "Vendor Id")]
        public int Vendor_Id{ get; set; }

        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Support Number")]
        public String SupportNumber{ get; set; }

        [Required]
        [Display(Name = "Support Email")]
        [EmailAddress]
        public String SupportEmail { get; set; }

        [Required]
        [Display(Name = "Website")]
        public String website { get; set; }
    }
}
