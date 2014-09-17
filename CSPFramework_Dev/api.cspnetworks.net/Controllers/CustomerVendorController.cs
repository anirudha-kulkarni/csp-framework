using CSPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Transactions;
using Newtonsoft.Json;

namespace api.cspnetworks.net.Controllers
{
    public class CustomerVendorController : ApiController
    {
        private CSPFRAMEWORKEntities _context;

        public CustomerVendorController()
        {
            _context = new CSPFRAMEWORKEntities();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET api/Vendors/GetVendors
        [HttpGet]
        public List<NewCustomerVendorModel> GetCustomerVendors()
        {
            IQueryable<Customer_Vendors> custVendors = _context.Customer_Vendors;
            List<NewCustomerVendorModel> regCustVendors = new List<NewCustomerVendorModel>();
            foreach (Customer_Vendors custVendor in custVendors)
            {
                NewCustomerVendorModel regCustVendor = new NewCustomerVendorModel();
                regCustVendor.Customer_Vendor_Id = custVendor.customer_vendor_id;
                regCustVendor.Vendor_Id = custVendor.vendor_id;
                regCustVendor.VendorName = custVendor.Vendor.name;
                regCustVendor.Account = custVendor.account_number;
                regCustVendor.Function = custVendor.function_name;
                regCustVendor.FunctionString = custVendor.FunctionName_Enum_Type_Values.enum_type_value;
                //regCustVendor.FunctionNotes = custVendor.function_notes;
                regCustVendor.L1UserName = custVendor.username_L1;
                regCustVendor.L1Password = custVendor.password_L1;
                regCustVendor.L2UserName = custVendor.username_L2;
                regCustVendor.L2Password = custVendor.password_L2;
                if (custVendor.Agreement != null)
                {
                    regCustVendor.AgreementPath = custVendor.Agreement.filepath;
                    regCustVendor.AgreementStartDate = custVendor.Agreement.start_date;
                    regCustVendor.AgreementEndDate = custVendor.Agreement.end_date;
                }
                regCustVendor.StatusString = custVendor.Status_Enum_Type_Values.enum_type_value;
                regCustVendor.Status = custVendor.status;
                if (custVendor.Function_Notes != null)
                {
                    regCustVendor.SolutionString = custVendor.Function_Notes.solution;
                }

                regCustVendor.Client_Id = custVendor.client_id;
                if (custVendor.Client != null)
                {
                    regCustVendor.ClientCode = custVendor.Client.client_code;
                }
                regCustVendor.Site = custVendor.site;
                regCustVendors.Add(regCustVendor);
            }
            return regCustVendors;
        }

        [ResponseType(typeof(Customer_Vendors))]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IHttpActionResult> PostNewCustomerVendor(CustomerVendorViewModelPost newCustomerVendorViewModel)
        {
            try
            {
                Function_Notes functionNotes = GetFunctionNotes(newCustomerVendorViewModel);

                Customer_Vendors custVendor = new Customer_Vendors();
                custVendor.vendor_id = newCustomerVendorViewModel.newCustomerVendorModel.Vendor_Id;
                custVendor.account_number = newCustomerVendorViewModel.newCustomerVendorModel.Account;
                custVendor.function_name = newCustomerVendorViewModel.newCustomerVendorModel.Function;

                custVendor.username_L1 = newCustomerVendorViewModel.newCustomerVendorModel.L1UserName;
                custVendor.password_L1 = newCustomerVendorViewModel.newCustomerVendorModel.L1Password;
                custVendor.username_L2 = newCustomerVendorViewModel.newCustomerVendorModel.L2UserName;
                custVendor.password_L2 = newCustomerVendorViewModel.newCustomerVendorModel.L2Password;

                custVendor.status = newCustomerVendorViewModel.newCustomerVendorModel.Status;
                custVendor.client_id = newCustomerVendorViewModel.newCustomerVendorModel.Client_Id;
                custVendor.site = newCustomerVendorViewModel.newCustomerVendorModel.Site;

                Agreement agreement = null;
                bool isAgreement = (!String.IsNullOrEmpty(newCustomerVendorViewModel.newCustomerVendorModel.AgreementPath) ||
                    newCustomerVendorViewModel.newCustomerVendorModel.AgreementStartDate != null ||
                    newCustomerVendorViewModel.newCustomerVendorModel.AgreementEndDate != null);

                if (isAgreement)
                {
                    agreement = new Agreement();
                    agreement.filepath = newCustomerVendorViewModel.newCustomerVendorModel.AgreementPath;
                    agreement.start_date = newCustomerVendorViewModel.newCustomerVendorModel.AgreementStartDate;
                    agreement.end_date = newCustomerVendorViewModel.newCustomerVendorModel.AgreementEndDate;
                }

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (agreement != null)
                    {
                        _context.Agreements.Add(agreement);                        
                        custVendor.agreement_id = agreement.agreement_id;
                    }
                    if (functionNotes != null)
                    {
                        _context.Function_Notes.Add(functionNotes);                       
                        custVendor.FunctionNotes_Id = functionNotes.FunctionNotes_Id;
                    }
                    _context.Customer_Vendors.Add(custVendor);
                    await _context.SaveChangesAsync();
                    scope.Complete();
                }

                return CreatedAtRoute("DefaultApi", new { id = custVendor.customer_vendor_id }, custVendor);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // GET api/Vendors/GetVendor/5
        [HttpGet]
        [ResponseType(typeof(CustomerVendorViewModelPost))]
        public async Task<IHttpActionResult> GetCustomerVendor(int custvendorid)
        {
            Customer_Vendors custVendor = await _context.Customer_Vendors.FindAsync(custvendorid);
            if (custVendor == null)
            {
                return NotFound();
            }

            CustomerVendorViewModelPost custVendorModel = new CustomerVendorViewModelPost();
            custVendorModel.newCustomerVendorModel = new NewCustomerVendorModel();
            custVendorModel.newCustomerVendorModel.Customer_Vendor_Id = custVendor.customer_vendor_id;
            custVendorModel.newCustomerVendorModel.Vendor_Id = custVendor.vendor_id;
            custVendorModel.newCustomerVendorModel.VendorName = custVendor.Vendor.name;
            custVendorModel.newCustomerVendorModel.Account = custVendor.account_number;
            custVendorModel.newCustomerVendorModel.Function = custVendor.function_name;
            custVendorModel.newCustomerVendorModel.FunctionString = custVendor.FunctionName_Enum_Type_Values.enum_type_value;

            if (custVendor.Function_Notes != null)
            {
                switch (custVendorModel.newCustomerVendorModel.FunctionString)
                {
                    case "Application":
                        Fun_Application funApp = new Fun_Application();
                        funApp.App_Solution = custVendor.Function_Notes.solution;
                        funApp.App_IP_Address = custVendor.Function_Notes.ip_address;
                        funApp.App_Login_Url = custVendor.Function_Notes.login_url;
                        funApp.App_Management_Url = custVendor.Function_Notes.management_url;
                        custVendorModel.iFunction = funApp;
                        break;
                    case "Fax":
                        Fun_Fax funFax = new Fun_Fax();
                        funFax.Fax_Solution = custVendor.Function_Notes.solution;
                        funFax.Fax_Number = custVendor.Function_Notes.fax_number;
                        funFax.Fax_Management_Url = custVendor.Function_Notes.management_url;
                        custVendorModel.iFunction = funFax;
                        break;
                    case "Phone System":
                        Fun_Phone_System funPhoneSys = new Fun_Phone_System();
                        funPhoneSys.Phone_Sys_Solution = custVendor.Function_Notes.solution;
                        funPhoneSys.Phone_Sys_IP_Address = custVendor.Function_Notes.ip_address;
                        funPhoneSys.Phone_Sys_Management_Url = custVendor.Function_Notes.management_url;
                        custVendorModel.iFunction = funPhoneSys;
                        break;
                    case "Connectivity - Phone":
                        Fun_Connectivity_Phone funConnPhone = new Fun_Connectivity_Phone();
                        funConnPhone.Conn_Phone_Solution = custVendor.Function_Notes.solution;
                        funConnPhone.Conn_Phone_Phone_Number = custVendor.Function_Notes.phone_number;
                        funConnPhone.Conn_Phone_Management_Url = custVendor.Function_Notes.management_url;
                        custVendorModel.iFunction = funConnPhone;
                        break;
                    case "Cloud":
                        Fun_Cloud funCloud = new Fun_Cloud();
                        funCloud.Cloud_Solution = custVendor.Function_Notes.solution;
                        funCloud.Cloud_IP_Address = custVendor.Function_Notes.ip_address;
                        funCloud.Cloud_Management_Url = custVendor.Function_Notes.management_url;
                        custVendorModel.iFunction = funCloud;
                        break;
                    case "Connectivity - Internet":
                        Fun_Connectivity_Internet funConnInt = new Fun_Connectivity_Internet();
                        funConnInt.Conn_Int_Solution = custVendor.Function_Notes.solution;
                        funConnInt.Conn_Int_Connectivity = custVendor.Function_Notes.connectivity;
                        funConnInt.Conn_Int_Wan_IP_Address = custVendor.Function_Notes.ip_address;
                        funConnInt.Conn_Int_Wan_IPs = custVendor.Function_Notes.WAN_IPs;
                        funConnInt.Conn_Int_SubnetMask = custVendor.Function_Notes.subnet_mask;
                        funConnInt.Conn_Int_DNS1 = custVendor.Function_Notes.DNS1;
                        funConnInt.Conn_Int_DNS2 = custVendor.Function_Notes.DNS2;
                        funConnInt.Conn_Int_Management_Url = custVendor.Function_Notes.management_url;
                        custVendorModel.iFunction = funConnInt;
                        break;
                    case "Printer":
                        Fun_Printer funPrinter = new Fun_Printer();
                        funPrinter.Printer_Solution = custVendor.Function_Notes.solution;
                        funPrinter.Printer_IP_Address = custVendor.Function_Notes.ip_address;
                        funPrinter.Printer_Management_Url = custVendor.Function_Notes.management_url;
                        custVendorModel.iFunction = funPrinter;
                        break;
                    default:
                        break;
                }
            }

            custVendorModel.newCustomerVendorModel.L1UserName = custVendor.username_L1;
            custVendorModel.newCustomerVendorModel.L1Password = custVendor.password_L1;
            custVendorModel.newCustomerVendorModel.L2UserName = custVendor.username_L2;
            custVendorModel.newCustomerVendorModel.L2Password = custVendor.password_L2;

            if (custVendor.Agreement != null)
            {
                custVendorModel.newCustomerVendorModel.AgreementPath = custVendor.Agreement.filepath;
                custVendorModel.newCustomerVendorModel.AgreementStartDate = custVendor.Agreement.start_date;
                custVendorModel.newCustomerVendorModel.AgreementEndDate = custVendor.Agreement.end_date;
            }

            custVendorModel.newCustomerVendorModel.StatusString = custVendor.Status_Enum_Type_Values.enum_type_value;
            custVendorModel.newCustomerVendorModel.Status = custVendor.status;

            if (custVendor.Client != null)
            {
                custVendorModel.newCustomerVendorModel.Client_Id = custVendor.Client.client_id;
                custVendorModel.newCustomerVendorModel.ClientCode = custVendor.Client.client_code;
            }
            custVendorModel.newCustomerVendorModel.Site = custVendor.site;

            return Ok(custVendorModel);
        }


        [HttpDelete]
        [ResponseType(typeof(Customer_Vendors))]
        public async Task<IHttpActionResult> DeleteCustomerVendor(int custvendorid)
        {
            Customer_Vendors custVendor = await _context.Customer_Vendors.FindAsync(custvendorid);
            if (custVendor == null)
            {
                return NotFound();
            }

            Function_Notes functionNotes = null;
            if (custVendor.Function_Notes != null)
            {
                functionNotes = await _context.Function_Notes.FindAsync(custVendor.Function_Notes.FunctionNotes_Id);
            }

            Agreement agreement = null;
            if (custVendor.Agreement != null)
            {
                agreement = await _context.Agreements.FindAsync(custVendor.Agreement.agreement_id);
            }

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
            {
                if (functionNotes != null)
                {
                    _context.Function_Notes.Remove(functionNotes);                    
                }
                if (agreement != null)
                {
                    _context.Agreements.Remove(agreement);                   
                }
                _context.Customer_Vendors.Remove(custVendor);
                await _context.SaveChangesAsync();
                scope.Complete();
            }
            return Ok(custVendor);
        }

        [HttpPost]
        [ResponseType(typeof(Customer_Vendors))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> UpdateCustomerVendor(CustomerVendorViewModelPost updatedCustVendor)
        {
            try
            {
                Agreement agreement = null;
                Customer_Vendors oldCustVendor = (from oldcustVendorInfo in _context.Customer_Vendors
                                                  where oldcustVendorInfo.customer_vendor_id == updatedCustVendor.newCustomerVendorModel.Customer_Vendor_Id
                                                  select oldcustVendorInfo).FirstOrDefault();
                if (oldCustVendor != null)
                {
                    oldCustVendor.vendor_id = updatedCustVendor.newCustomerVendorModel.Vendor_Id;
                    oldCustVendor.client_id = updatedCustVendor.newCustomerVendorModel.Client_Id;
                    oldCustVendor.account_number = updatedCustVendor.newCustomerVendorModel.Account;
                    oldCustVendor.username_L1 = updatedCustVendor.newCustomerVendorModel.L1UserName;
                    oldCustVendor.password_L1 = updatedCustVendor.newCustomerVendorModel.L1Password;
                    oldCustVendor.username_L2 = updatedCustVendor.newCustomerVendorModel.L2UserName;
                    oldCustVendor.password_L2 = updatedCustVendor.newCustomerVendorModel.L2Password;
                    if (oldCustVendor.Agreement != null)
                    {
                        oldCustVendor.Agreement.filepath = updatedCustVendor.newCustomerVendorModel.AgreementPath;
                        oldCustVendor.Agreement.start_date = updatedCustVendor.newCustomerVendorModel.AgreementStartDate;
                        oldCustVendor.Agreement.end_date = updatedCustVendor.newCustomerVendorModel.AgreementEndDate;
                    }
                    else
                    {
                       bool isAgreement = (!String.IsNullOrEmpty(updatedCustVendor.newCustomerVendorModel.AgreementPath) ||
                                                        updatedCustVendor.newCustomerVendorModel.AgreementStartDate != null ||
                                                        updatedCustVendor.newCustomerVendorModel.AgreementEndDate != null);
                        if (isAgreement)
                        {
                            agreement = new Agreement();
                            agreement.filepath = updatedCustVendor.newCustomerVendorModel.AgreementPath;
                            agreement.start_date = updatedCustVendor.newCustomerVendorModel.AgreementStartDate;
                            agreement.end_date = updatedCustVendor.newCustomerVendorModel.AgreementEndDate;
                        }
                    }

                    oldCustVendor.status = updatedCustVendor.newCustomerVendorModel.Status;
                    oldCustVendor.site = updatedCustVendor.newCustomerVendorModel.Site;
                    oldCustVendor.function_name = updatedCustVendor.newCustomerVendorModel.Function;

                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
                    {
                        
                        if (agreement != null)
                        {
                            _context.Agreements.Add(agreement);                            
                            oldCustVendor.agreement_id = agreement.agreement_id;
                        }

                        if (updatedCustVendor.iFunction != null)
                        {
                            Function_Notes functionNotes = GetFunctionNotes(updatedCustVendor);

                            if (oldCustVendor.Function_Notes != null)
                            {
                                oldCustVendor.Function_Notes.solution = functionNotes.solution;
                                oldCustVendor.Function_Notes.connectivity = functionNotes.connectivity;
                                oldCustVendor.Function_Notes.ip_address = functionNotes.ip_address;
                                oldCustVendor.Function_Notes.login_url = functionNotes.login_url;
                                oldCustVendor.Function_Notes.management_url = functionNotes.management_url;
                                oldCustVendor.Function_Notes.fax_number = functionNotes.fax_number;
                                oldCustVendor.Function_Notes.phone_number = functionNotes.phone_number;
                                oldCustVendor.Function_Notes.subnet_mask = functionNotes.subnet_mask;
                                oldCustVendor.Function_Notes.DNS1 = functionNotes.DNS1;
                                oldCustVendor.Function_Notes.DNS2 = functionNotes.DNS2;
                                oldCustVendor.Function_Notes.WAN_IPs = functionNotes.WAN_IPs;
                            }
                            else if (functionNotes != null)
                            {
                                _context.Function_Notes.Add(functionNotes);                                
                                oldCustVendor.FunctionNotes_Id  = functionNotes.FunctionNotes_Id;
                            }
                        }
                        await _context.SaveChangesAsync();
                        scope.Complete();
                        return CreatedAtRoute("DefaultApi", new { id = oldCustVendor.customer_vendor_id }, oldCustVendor);
                    }

                }
                return NotFound();
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        private Function_Notes GetFunctionNotes(CustomerVendorViewModelPost customerVendorViewModelPost)
        {
            Function_Notes functionNotes = null;
            if (String.IsNullOrEmpty(customerVendorViewModelPost.newCustomerVendorModel.FunctionString))
            {
                return null;
            }
            switch (customerVendorViewModelPost.newCustomerVendorModel.FunctionString)
            {
                case "Application":
                    {
                        Fun_Application funApp = JsonConvert.DeserializeObject<Fun_Application>(customerVendorViewModelPost.iFunction.ToString());
                        functionNotes = new Function_Notes();
                        functionNotes.solution = funApp.App_Solution;
                        functionNotes.ip_address = funApp.App_IP_Address;
                        functionNotes.login_url = funApp.App_Login_Url;
                        functionNotes.management_url = funApp.App_Management_Url;
                    }
                    break;
                case "Fax":
                    {
                        Fun_Fax funFax = JsonConvert.DeserializeObject<Fun_Fax>(customerVendorViewModelPost.iFunction.ToString());
                        functionNotes = new Function_Notes();
                        functionNotes.solution = funFax.Fax_Solution;
                        functionNotes.fax_number = funFax.Fax_Number;
                        functionNotes.management_url = funFax.Fax_Management_Url;
                    }
                    break;
                case "Phone System":
                    {
                        Fun_Phone_System funPhoneSys = JsonConvert.DeserializeObject<Fun_Phone_System>(customerVendorViewModelPost.iFunction.ToString());
                        functionNotes = new Function_Notes();
                        functionNotes.solution = funPhoneSys.Phone_Sys_Solution;
                        functionNotes.ip_address = funPhoneSys.Phone_Sys_IP_Address;
                        functionNotes.management_url = funPhoneSys.Phone_Sys_Management_Url;
                    }
                    break;
                case "Connectivity - Phone":
                    {
                        Fun_Connectivity_Phone funConnPhone = JsonConvert.DeserializeObject<Fun_Connectivity_Phone>(customerVendorViewModelPost.iFunction.ToString());
                        functionNotes = new Function_Notes();
                        functionNotes.solution = funConnPhone.Conn_Phone_Solution;
                        functionNotes.phone_number = funConnPhone.Conn_Phone_Phone_Number;
                        functionNotes.management_url = funConnPhone.Conn_Phone_Management_Url;
                    }
                    break;
                case "Cloud":
                    {
                        Fun_Cloud funCloud = JsonConvert.DeserializeObject<Fun_Cloud>(customerVendorViewModelPost.iFunction.ToString());
                        functionNotes = new Function_Notes();
                        functionNotes.solution = funCloud.Cloud_Solution;
                        functionNotes.ip_address = funCloud.Cloud_IP_Address;
                        functionNotes.management_url = funCloud.Cloud_Management_Url;
                    }
                    break;
                case "Connectivity - Internet":
                    {
                        Fun_Connectivity_Internet funConnInt = JsonConvert.DeserializeObject<Fun_Connectivity_Internet>(customerVendorViewModelPost.iFunction.ToString());
                        functionNotes = new Function_Notes();
                        functionNotes.solution = funConnInt.Conn_Int_Solution;
                        functionNotes.connectivity = funConnInt.Conn_Int_Connectivity;
                        functionNotes.ip_address = funConnInt.Conn_Int_Wan_IP_Address;
                        functionNotes.WAN_IPs = funConnInt.Conn_Int_Wan_IPs;
                        functionNotes.subnet_mask = funConnInt.Conn_Int_SubnetMask;
                        functionNotes.DNS1 = funConnInt.Conn_Int_DNS1;
                        functionNotes.DNS2 = funConnInt.Conn_Int_DNS2;
                        functionNotes.management_url = funConnInt.Conn_Int_Management_Url;
                    }
                    break;
                case "Printer":
                    {
                        Fun_Printer funPrinter = JsonConvert.DeserializeObject<Fun_Printer>(customerVendorViewModelPost.iFunction.ToString());
                        functionNotes = new Function_Notes();
                        functionNotes.solution = funPrinter.Printer_Solution;
                        functionNotes.ip_address = funPrinter.Printer_IP_Address;
                        functionNotes.management_url = funPrinter.Printer_Management_Url;
                    }
                    break;
                default:
                    break;
            }
            return functionNotes;
        }
    }
}
