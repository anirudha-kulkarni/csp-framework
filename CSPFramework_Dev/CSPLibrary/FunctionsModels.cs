using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPLibrary
{
    public class ISP
    {
        [Display(Name= "IP")]
        public String IP { get; set; }

        [Display(Name = "Subnet Mask")]
        public String SubnetMask { get; set; }

        [Display(Name = "DNS 1")]
        public String DNS1 { get; set; }

        [Display(Name = "DNS 2")]
        public String DNS2 { get; set; }
    }
}
