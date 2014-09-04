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

namespace api.cspportal.com.Controllers
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
                regCustVendor.FunctionNotes = custVendor.function_notes;
                regCustVendor.L1UserName = custVendor.username_L1;
                regCustVendor.L1Password = custVendor.password_L1;
                regCustVendor.L2UserName = custVendor.username_L2;
                regCustVendor.L2Password = custVendor.password_L2;
                if(custVendor.Agreement != null)
                {
                    regCustVendor.AgreementPath = custVendor.Agreement.filepath;
                    regCustVendor.AgreementStartDate = custVendor.Agreement.start_date;
                    regCustVendor.AgreementEndDate = custVendor.Agreement.end_date;
                }                
                regCustVendor.Status = custVendor.status;
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
            String functionNotes = "";
            if (newCustomerVendorViewModel.isp != null)
            {
                functionNotes = JsonConvert.SerializeObject(newCustomerVendorViewModel.isp);
            }
                        
            Customer_Vendors custVendor = new Customer_Vendors();
            custVendor.vendor_id = newCustomerVendorViewModel.newCustomerVendorModel.Vendor_Id;
            custVendor.account_number = newCustomerVendorViewModel.newCustomerVendorModel.Account;
            custVendor.function_name = newCustomerVendorViewModel.newCustomerVendorModel.Function;
            custVendor.function_notes = functionNotes;
            custVendor.username_L1 = newCustomerVendorViewModel.newCustomerVendorModel.L1UserName;
            custVendor.password_L1 = newCustomerVendorViewModel.newCustomerVendorModel.L1Password;
            custVendor.username_L2 = newCustomerVendorViewModel.newCustomerVendorModel.L2UserName;
            custVendor.password_L2 = newCustomerVendorViewModel.newCustomerVendorModel.L2Password;

            custVendor.status = newCustomerVendorViewModel.newCustomerVendorModel.Status;
            custVendor.client_id = newCustomerVendorViewModel.newCustomerVendorModel.Client_Id;
            custVendor.site = newCustomerVendorViewModel.newCustomerVendorModel.Site;

            Agreement agreement = null;
            if (newCustomerVendorViewModel.newCustomerVendorModel.AgreementPath != null &&  
                ! String.IsNullOrEmpty(newCustomerVendorViewModel.newCustomerVendorModel.AgreementPath))
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
                    await _context.SaveChangesAsync();
                    custVendor.agreement_id = agreement.agreement_id;
                }
                _context.Customer_Vendors.Add(custVendor);
                await _context.SaveChangesAsync();
                scope.Complete();
            }

            return CreatedAtRoute("DefaultApi", new { id = custVendor.customer_vendor_id }, custVendor);
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
            custVendorModel.newCustomerVendorModel.Vendor_Id = custVendor.vendor_id;
            custVendorModel.newCustomerVendorModel.VendorName = custVendor.Vendor.name;
            custVendorModel.newCustomerVendorModel.Account = custVendor.account_number;
            custVendorModel.newCustomerVendorModel.Function = custVendor.function_name;
            string functionNotes = custVendor.function_notes;
            if (custVendor.function_name == "ISP" && ! String.IsNullOrEmpty(functionNotes))
            {
                custVendorModel.isp = new ISP();
                custVendorModel.isp = JsonConvert.DeserializeObject<ISP>(functionNotes);
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

            _context.Customer_Vendors.Remove(custVendor);
            await _context.SaveChangesAsync();

            return Ok(custVendor);
        }
    }
}
