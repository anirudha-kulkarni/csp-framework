using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPLibrary
{
    public class ClientsViewModel
    {
        public IEnumerable<CSPLibrary.NewClientModel> RegisteredClientsList { get; set; }        
    }

    public class ClientSite
    {
        [Display(Name = "Address")]
        public String Address { get; set; }

        [Display(Name = "City")]
        public String City { get; set; }

        [Display(Name = "State")]
        public String State { get; set; }

        [Display(Name = "Zip")]
        public String Zip { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }

        [Display(Name = "Fax Number")]
        [DataType(DataType.PhoneNumber)]
        public String FaxNumber { get; set; }
    }

    public class NewClientViewModel
    {
        public NewClientModel newClientModel { get; set; }
        public List<ClientSite> clientSites { get; set; }
    }

    public class NewClientModel
    {
        [Required]
        [Display(Name = "Client Id")]
        public int Client_Id { get; set; }

        [Required]
        [Display(Name = "Client Code")]
        public string Client_Code{ get; set; }
        
        [Required]
        [Display(Name = "Company Name")]
        public String Company_Name { get; set; }

        
        //[Display(Name = "Address")]
        //public String Address{ get; set; }

        
        //[Display(Name = "City")]
        //public String City { get; set; }

        //[Display(Name = "State")]
        //public String State { get; set; }

        //[Display(Name = "Zip")]
        //public String Zip { get; set; }

        //[Required]
        //[Display(Name = "Phone Number")]
        //[DataType(DataType.PhoneNumber)]
        //public String PhoneNumber { get; set; }

        //[Display(Name = "Mobile Number")]
        //[DataType(DataType.PhoneNumber)]
        //public String MobileNumber { get; set; }

        [Required]
        [Display(Name = "Website")]
        public String Website { get; set; }

        [Required]
        [Display(Name = "Service Type")]
        public String ServiceTypeString { get; set; }

        [Required]
        [Display(Name = "Service Type")]
        public int? ServiceType { get; set; }

        [Display(Name = "Agreement Start Date")]
        public DateTime? AgreementStartDate { get; set; }

        [Display(Name = "Agreement End Date")]
        public DateTime? AgreementEndDate { get; set; }

        [Required]
        [Display(Name = "Team")]
        public int? Team { get; set; }

        [Required]
        [Display(Name = "Team")]
        public String TeamString { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int? Status { get; set; }

        [Required]
        [Display(Name = "Status")]
        public String StatusString { get; set; }

        [Required]
        [Display(Name = "Sites")]
        public String Sites { get; set; }

    }
}
