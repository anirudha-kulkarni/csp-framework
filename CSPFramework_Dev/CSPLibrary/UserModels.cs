using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSPLibrary
{
    public class LoginModel
    {
        public UserLoginModel userLoginModel { get; set; }
    }
    public class UserLoginModel
    {
        //[Required]
        //[Display(Name = "User Name")]
        //public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
    public class RegisteredUserModel
    {
        [Required]
        [Display(Name = "User Id")]
        public int User_Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FisrtName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public String MobileNumber { get; set; }

        [Required]
        [Display(Name = "Account Role")]
        public String AccountRole { get; set; }        
    }        
    public class NewUserModel
    {

        [Required]
        [Display(Name = "User Id")]
        public int User_Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
               
        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Account Role")]
        public String AccountRole { get; set; }

        [Display(Name = "Customer Id")]
        public int? Customer_Id { get; set; }

        [Display(Name = "Customer Name")]
        public string Customer_Name { get; set; }

        [Display(Name = "Status")]
        public int? Status { get; set; }

        [Display(Name = "Status String")]
        public string StatusString { get; set; }   

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public String Phone { get; set; }

        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public String MobileNumber { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
    }

    public class ChangePasswordModel
    {
        [Required]
        [Display(Name = "User Id")]
        public int User_Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "New Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("Password", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}