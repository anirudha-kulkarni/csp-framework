using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CSPLibrary
{
    public class NewSoftwareModel
    {
        [Required]
        [Display(Name = "Software Id")]
        public int Software_ID { get; set; }

        [Required]
        [Display(Name = "Make")]
        public int Make_ID { get; set; }
        [Required]
        [Display(Name = "Make Name")]
        public string MakeName { get; set; }
        [Display(Name = "Is New Make")]
        public string IsNewMake { get; set; }


        [Required]
        [Display(Name = "Model")]
        public int Model_ID { get; set; }
        [Required]
        [Display(Name = "Model Name")]
        public string ModelName { get; set; }
        [Display(Name = "Is New Model")]
        public string IsNewModel { get; set; }


        [Display(Name = "Box Product Key")]
        public string Box_Product_Key { get; set; }
        [Display(Name = "Digital Product Key")]
        public string Digital_Product_Key { get; set; }


        [Required]
        [Display(Name = "License Type")]
        public int License_ID { get; set; }
        [Display(Name = "License Type Name")]
        public string License_Type_Name { get; set; }


        [Required]
        [Display(Name = "Media Type")]
        public int Media_ID { get; set; }
        [Display(Name = "Media Type Name")]
        public string Media_Type_Name { get; set; }


        [Required]
        [Display(Name = "Purchased By")]
        public int PurchasedBy_ID { get; set; }
        [Display(Name = "Purchased By Name")]
        public string PurchasedBy_Name { get; set; }


        [Required]
        [Display(Name = "Client ID")]
        public int Client_ID { get; set; }
        [Display(Name = "Client Code")]
        public string ClientCode { get; set; }


        [Required]
        [Display(Name = "Location ID")]
        public int site_id { get; set; }
        [Display(Name = "Location Name")]
        public string Location_Name { get; set; }
    }

    public class SoftwareViewModel
    {
        public IEnumerable<CSPLibrary.NewSoftwareModel> RegisteredSoftwareList { get; set; }
        public NewSoftwareModel NewSoftwareRegistrationModel { get; set; }
    }
}
