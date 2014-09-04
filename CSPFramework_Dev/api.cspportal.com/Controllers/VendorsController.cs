using CSPLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace api.cspportal.com.Controllers
{
    public class VendorsController : ApiController
    {
         private CSPFRAMEWORKEntities _context;

         public VendorsController()
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
        public List<NewVendorModel> GetVendors()
        {
            IQueryable<Vendor> vendors = _context.Vendors;
            List<NewVendorModel> regVendors = new List<NewVendorModel>();
            foreach (Vendor vendor in vendors)
            {
                NewVendorModel regVendor = new NewVendorModel();
                regVendor.Vendor_Id = vendor.vendor_id;
                regVendor.Name = vendor.name;
                regVendor.SupportEmail = vendor.support_email;
                regVendor.SupportNumber = vendor.support_number;
                regVendor.website = vendor.website;
                regVendors.Add(regVendor);
            }
            return regVendors;
        }

        // POST : api/Vendors/PostVendor
        [ResponseType(typeof(Vendor))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> PostVendor(NewVendorModel newVendor)
        {
            //NewUserModel newUser = viewmodel.NewUserRegistrationModel;
            //NewUserModel newUser = addNewUser.newUserModel;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Vendor vendor = new Vendor();
                vendor.name = newVendor.Name;
                vendor.support_email = newVendor.SupportEmail;
                vendor.support_number = newVendor.SupportNumber;
                vendor.website = newVendor.website;

                _context.Vendors.Add(vendor);
                await _context.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = vendor.vendor_id }, vendor);

            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        // GET api/Vendors/GetVendor/5
        [ResponseType(typeof(NewVendorModel))]
        public async Task<IHttpActionResult> GetVendor(int id)
        {
            Vendor vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            NewVendorModel vendorModel = new NewVendorModel();
            vendorModel.Vendor_Id = vendor.vendor_id;
            vendorModel.Name = vendor.name;
            vendorModel.SupportEmail = vendor.support_email;
            vendorModel.SupportNumber = vendor.support_number;
            vendorModel.website = vendor.website;
            return Ok(vendorModel);
        }

        [ResponseType(typeof(NewVendorModel))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> UpdateVendor(NewVendorModel updatedVendor)
        {
            try
            {
                Vendor oldVendor = (from oldVendorInfo in _context.Vendors
                                where oldVendorInfo.vendor_id == updatedVendor.Vendor_Id
                                    select oldVendorInfo).FirstOrDefault();
                if (oldVendor != null)
                {
                    oldVendor.name = updatedVendor.Name;
                    oldVendor.support_email = updatedVendor.SupportEmail;
                    oldVendor.support_number = updatedVendor.SupportNumber;
                    oldVendor.website = updatedVendor.website;                    
                }

                await _context.SaveChangesAsync();
                return CreatedAtRoute("DefaultApi", new { id = oldVendor.vendor_id }, oldVendor );
            }
            catch (Exception)
            {

                throw new InvalidOperationException();
            }
        }

        // DELETE api/Vendors/DeleteVendor/5
        [HttpDelete]
        [ResponseType(typeof(Vendor))]
        public async Task<IHttpActionResult> DeleteVendor(int id)
        {
            Vendor vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return Ok(vendor);
        }
    }
}
