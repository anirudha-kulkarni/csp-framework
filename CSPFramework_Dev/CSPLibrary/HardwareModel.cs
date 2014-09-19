using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CSPLibrary
{
    public class NewHardwareModel
    {
        [Required]
        [Display(Name = "Hardware Id")]
        public int Hardware_Id { get; set; }

        [Required]
        [Display(Name = "Vendor ID")] 
        public int Vendor_ID { get; set; }

        [Display(Name = "Vendor Name")]
        public string Vendor_Name { get; set; }

        [Display(Name = "Serial Number")]
        public string Serial_Number { get; set; }

        [Display(Name = "Make")]
        public int? Make { get; set; }

        [Display(Name = "Make Name")]
        public string MakeName { get; set; }

        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Item")]
        public int Item { get; set; }

        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Associated Hardware ID")]
        public int? Associted_Hardware_Id { get; set; }

        [Display(Name = "Software ID")]
        public int Software_ID { get; set; }

        [Display(Name = "Softwware Name")]
        public string SoftwareName { get; set; }

        [Display(Name = "Warranty Start")]
        [DataType(DataType.DateTime)]
        public DateTime? WarrantyStart { get; set; }

        [Display(Name = "Warranty End")]
        [DataType(DataType.DateTime)]
        public DateTime? WarrantyEnd { get; set; }

        [Required]
        [Display(Name = "Purchased By")]
        public int PurchasedBy { get; set; }

        [Display(Name = "Purchaser Name")]
        public string PurchaserName { get; set; }

        [Required]
        [Display(Name = "Client ID")]
        public int ClientId { get; set; }

        [Display(Name = "Client Code")]
        public string ClientCode { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Hardware Status")]
        public int? Hardware_Status { get; set; }

        [Display(Name = "Hardware Status Name")]
        public string Hardware_Status_Value { get; set; }
    }

    public class HardwareViewModel
    {
        public IEnumerable<CSPLibrary.NewHardwareModel> RegisteredHardwareList { get; set; }
        public NewHardwareModel NewHardwareRegistrationModel { get; set; }
    }
}
