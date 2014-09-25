using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSPLibrary;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace api.cspnetworks.net.Controllers
{
    public class SoftwareController : ApiController
    {
        private CSPFRAMEWORKEntities _context;

        public SoftwareController()
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
        //

        private int AddNewMakeModel(string makemodelname, string data)
        {
            // save into enum_type_value db
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == data
                                   select enums).FirstOrDefault();

            Enum_Type_Values newEnum = new Enum_Type_Values();
            newEnum.enum_type_id = enumType.enum_type_id;
            newEnum.enum_type_value = makemodelname;
            _context.Enum_Type_Values.Add(newEnum);
            _context.SaveChanges();

            return newEnum.enum_type_value_id;
        }

        // POST : api/Software/PostSoftware
        [HttpPost]
        [ResponseType(typeof(Software))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> PostSoftware(NewSoftwareModel newSoftware)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Software _newSoftware = new Software();

                if (newSoftware.IsNewMake.ToLower() == "true")
                {
                    int value = AddNewMakeModel(newSoftware.MakeName, "Software_Makes");
                    _newSoftware.make = value;
                 }
                 else
                 {
                     _newSoftware.make = newSoftware.Make_ID;
                 }

                if (newSoftware.IsNewModel.ToLower() == "true")
                {
                    int value = AddNewMakeModel(newSoftware.ModelName, "Software_Models");
                    _newSoftware.model = value;
                }
                else
                {
                    _newSoftware.model = newSoftware.Model_ID;
                }
               
                _newSoftware.box_product_key = newSoftware.Box_Product_Key;
                _newSoftware.digital_product_key = newSoftware.Digital_Product_Key;

                _newSoftware.license_type = newSoftware.License_ID;
                _newSoftware.media_type = newSoftware.Media_ID;

                _newSoftware.purchased_by = newSoftware.PurchasedBy_ID;
                _newSoftware.client_id = newSoftware.Client_ID;
                _newSoftware.location = newSoftware.site_id;

                _context.Softwares.Add(_newSoftware);
                await _context.SaveChangesAsync();

                return Ok();

            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        // GET api/Software/GetSoftwareres
        [HttpGet]
        public List<NewSoftwareModel> GetSoftwares()
        {
            try
            {
                IQueryable<Software> _software = _context.Softwares;
                List<NewSoftwareModel> softwareList = new List<NewSoftwareModel>();
                foreach (Software software in _software)
                {
                    NewSoftwareModel softwareItem = new NewSoftwareModel();
                    softwareItem.Software_ID = software.CSPNAssetTag;
                    softwareItem.Make_ID = software.make;
                    softwareItem.MakeName = software.Make_Enum_Type_Values.enum_type_value;
                    softwareItem.Model_ID = software.model;
                    softwareItem.ModelName = software.Model_Enum_Type_Values.enum_type_value;
                    softwareItem.Box_Product_Key = software.box_product_key ;
                    softwareItem.Digital_Product_Key = software.digital_product_key;
                    softwareItem.License_ID = software.license_type;
                    softwareItem.License_Type_Name = software.License_Enum_Type_Values.enum_type_value;
                    softwareItem.Media_ID = software.media_type;
                    softwareItem.Media_Type_Name = software.Media_Enum_Type_Values.enum_type_value;

                    softwareItem.PurchasedBy_ID = software.purchased_by;
                    softwareItem.PurchasedBy_Name = software.PurchasedBy_Enum_Type_Values.enum_type_value;

                    softwareItem.Client_ID = software.client_id;
                    softwareItem.ClientCode = software.Client.client_code;

                    softwareItem.site_id = software.location;
                    softwareItem.Location_Name = software.Client_Site.site_name;
                    
                    softwareList.Add(softwareItem);
                }
                return softwareList;
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        [ResponseType(typeof(NewSoftwareModel))]
        public async Task<IHttpActionResult> GetSoftware(int id)
        {
            Software software = await _context.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            NewSoftwareModel softwareItem = new NewSoftwareModel();
            softwareItem.Software_ID = software.CSPNAssetTag;
            softwareItem.Make_ID = software.make;
            softwareItem.MakeName = software.Make_Enum_Type_Values.enum_type_value;
            softwareItem.Model_ID = software.model;
            softwareItem.ModelName = software.Model_Enum_Type_Values.enum_type_value;
            softwareItem.Box_Product_Key = software.box_product_key;
            softwareItem.Digital_Product_Key = software.digital_product_key;
            softwareItem.License_ID = software.license_type;
            softwareItem.License_Type_Name = software.License_Enum_Type_Values.enum_type_value;
            softwareItem.Media_ID = software.media_type;
            softwareItem.Media_Type_Name = software.Media_Enum_Type_Values.enum_type_value;

            softwareItem.PurchasedBy_ID = software.purchased_by;
            softwareItem.PurchasedBy_Name = software.PurchasedBy_Enum_Type_Values.enum_type_value;

            softwareItem.Client_ID = software.client_id;
            softwareItem.ClientCode = software.Client.client_code;

            softwareItem.site_id = software.location;
            softwareItem.Location_Name = software.Client_Site.site_name;

            return Ok(softwareItem);
        }

        [HttpPost]
        [ResponseType(typeof(NewSoftwareModel))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> UpdateSoftware(NewSoftwareModel updatedSoftware)
        {
            try
            {
                Software oldSoftware = (from oldSoftwareInfo in _context.Softwares
                                        where oldSoftwareInfo.CSPNAssetTag == updatedSoftware.Software_ID
                                        select oldSoftwareInfo).FirstOrDefault();

                if (oldSoftware != null)
                {
                    oldSoftware.make = updatedSoftware.Make_ID;
                    oldSoftware.model = updatedSoftware.Model_ID;
                    oldSoftware.box_product_key = updatedSoftware.Box_Product_Key;
                    oldSoftware.digital_product_key = updatedSoftware.Digital_Product_Key;
                    oldSoftware.license_type = updatedSoftware.License_ID;
                    oldSoftware.media_type = updatedSoftware.Media_ID;
                    oldSoftware.purchased_by = updatedSoftware.PurchasedBy_ID;
                    oldSoftware.client_id = updatedSoftware.Client_ID;
                    oldSoftware.location = updatedSoftware.site_id;
                }

                await _context.SaveChangesAsync();
                return Ok();

            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        [HttpDelete]
        [ResponseType(typeof(Software))]
        public async Task<IHttpActionResult> DeleteSoftware(int id)
        {
            Software software = await _context.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            _context.Softwares.Remove(software);
            await _context.SaveChangesAsync();

            return Ok(software);
        }
    }
}
