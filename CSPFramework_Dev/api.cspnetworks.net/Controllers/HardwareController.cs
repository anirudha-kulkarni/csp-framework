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
    public class HardwareController : ApiController
    {
        private CSPFRAMEWORKEntities _context;

        public HardwareController()
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

        // POST : api/Hardware/PostHardware
        [HttpPost]
        [ResponseType(typeof(Hardware))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> PostHardware(NewHardwareModel newHardware)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Hardware _hardware = new Hardware();
                _hardware.vendor_id = newHardware.Vendor_ID;
                _hardware.serial_number = newHardware.Serial_Number;
                _hardware.make = newHardware.Make;
                _hardware.model = newHardware.Model;
                _hardware.item = newHardware.Item;
                _hardware.associated_hardware_id = newHardware.Associted_Hardware_Id;

                if (newHardware.Software_ID == 0){
                    _hardware.software_id = null;
                }else{
                    _hardware.software_id = newHardware.Software_ID;
                }
                
                if (newHardware.WarrantyStart.HasValue) 
                {
                    _hardware.warrenty_start_date = newHardware.WarrantyStart.Value;
                }
                if (newHardware.WarrantyEnd.HasValue)
                {
                    _hardware.warrenty_end_date = newHardware.WarrantyEnd.Value;
                }
                
                _hardware.purchased_by = newHardware.PurchasedBy;
                _hardware.client_id = newHardware.ClientId;
                _hardware.location = newHardware.Location;
                _hardware.hardware_status = newHardware.Hardware_Status;

                _context.Hardwares.Add(_hardware);
                await _context.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = _hardware.CSPNAssetTag }, _hardware);

            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        // GET api/Hardware/GetHardwares
        [HttpGet]
        public List<NewHardwareModel> GetHardwares()
        {
            try
            {
                IQueryable<Hardware> _hardware = _context.Hardwares;
                List<NewHardwareModel> hardwareList = new List<NewHardwareModel>();
                foreach (Hardware hardware in _hardware)
                {
                    NewHardwareModel hardwareItem = new NewHardwareModel();
                    hardwareItem.Hardware_Id = hardware.CSPNAssetTag;

                    hardwareItem.Vendor_ID = hardware.vendor_id;
                    hardwareItem.Vendor_Name = hardware.Vendor.name;

                    hardwareItem.Serial_Number = hardware.serial_number;
                    hardwareItem.Make = hardware.Make_Enum_Type_Values.enum_type_value_id;
                    hardwareItem.Model = hardware.model;
                    hardwareItem.Item = hardware.item;
                    if(hardware.associated_hardware_id.HasValue)
                    {
                        hardwareItem.Associted_Hardware_Id = hardware.associated_hardware_id;
                    }
                    if (hardware.software_id.HasValue)
                    {
                        hardwareItem.Software_ID = hardware.software_id.Value;
                        hardwareItem.SoftwareName = hardware.Software.software_name;
                    }
                    hardwareItem.WarrantyStart = hardware.warrenty_start_date;
                    hardwareItem.WarrantyEnd = hardware.warrenty_end_date;

                    hardwareItem.PurchasedBy = hardware.purchased_by;
                    hardwareItem.PurchaserName = hardware.Purchased_Enum_Type_Values.enum_type_value;

                    hardwareItem.ClientId = hardware.client_id;
                    hardwareItem.ClientCode = hardware.Client.client_code;

                    hardwareItem.Location = hardware.location;
                    hardwareItem.Hardware_Status = hardware.hardware_status;
                    if (hardware.hardware_status.HasValue)
                    {
                        hardwareItem.Hardware_Status_Value = hardware.Status_Enum_Type_Values.enum_type_value;
                    }

                    hardwareList.Add(hardwareItem);
                }
                return hardwareList;
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }

        [ResponseType(typeof(NewHardwareModel))]
        public async Task<IHttpActionResult> GetHardware(int id)
        {
            Hardware hardware = await _context.Hardwares.FindAsync(id);
            if(hardware == null)
            {
                return NotFound();
            }

            NewHardwareModel hardwareItem = new NewHardwareModel();
            hardwareItem.Hardware_Id = hardware.CSPNAssetTag;
            hardwareItem.Vendor_ID = hardware.vendor_id;
            hardwareItem.Vendor_Name = hardware.Vendor.name;
            hardwareItem.Serial_Number = hardware.serial_number;
            hardwareItem.Make = hardware.Make_Enum_Type_Values.enum_type_value_id;
            hardwareItem.MakeName = hardware.Make_Enum_Type_Values.enum_type_value;
            hardwareItem.Model = hardware.model;
            hardwareItem.Item = hardware.item;
            hardwareItem.ItemName = hardware.Item_Enum_Type_Values.enum_type_value;
            hardwareItem.Associted_Hardware_Id = hardware.associated_hardware_id;
            
            if (hardware.software_id.HasValue)
            {
                hardwareItem.Software_ID = hardware.software_id.Value;
                hardwareItem.SoftwareName = hardware.Software.software_name;
            }
            
            hardwareItem.WarrantyStart = hardware.warrenty_start_date;
            hardwareItem.WarrantyEnd = hardware.warrenty_end_date;
            hardwareItem.PurchasedBy = hardware.purchased_by;
            hardwareItem.PurchaserName = hardware.Purchased_Enum_Type_Values.enum_type_value;
            hardwareItem.ClientId = hardware.client_id;
            hardwareItem.ClientCode = hardware.Client.client_code;

            hardwareItem.Location = hardware.location;
            hardwareItem.Hardware_Status = hardware.hardware_status;
            if (hardware.hardware_status.HasValue)
            {
                hardwareItem.Hardware_Status_Value = hardware.Status_Enum_Type_Values.enum_type_value;
            }

            return Ok(hardwareItem);
        }

        [HttpPost]
        [ResponseType(typeof(NewHardwareModel))]
        [AllowAnonymous]
        public async Task<IHttpActionResult> UpdateHardware(NewHardwareModel updatedHardware)
        {
            try
            {


                Hardware oldHardware = (from oldHardwareInfo in _context.Hardwares
                                        where oldHardwareInfo.CSPNAssetTag == updatedHardware.Hardware_Id
                                        select oldHardwareInfo).FirstOrDefault();


                if (oldHardware != null)
                {
                    oldHardware.vendor_id = updatedHardware.Vendor_ID;
                    oldHardware.serial_number = updatedHardware.Serial_Number;
                    oldHardware.make = updatedHardware.Make;
                    oldHardware.model = updatedHardware.Model;
                    oldHardware.item = updatedHardware.Item;
                    oldHardware.associated_hardware_id = updatedHardware.Associted_Hardware_Id;

                    if (updatedHardware.Software_ID == 0)
                    {
                        oldHardware.software_id = null;
                    }
                    else
                    {
                        oldHardware.software_id = updatedHardware.Software_ID;
                    }


                    if (updatedHardware.WarrantyStart.HasValue)
                    {
                        oldHardware.warrenty_start_date = updatedHardware.WarrantyStart.Value;
                    }
                    if (updatedHardware.WarrantyEnd.HasValue)
                    {
                        oldHardware.warrenty_end_date = updatedHardware.WarrantyEnd.Value;
                    }
                    oldHardware.purchased_by = updatedHardware.PurchasedBy;
                    oldHardware.client_id = updatedHardware.ClientId;
                    oldHardware.location = updatedHardware.Location;

                    if (updatedHardware.Hardware_Status.HasValue)
                    {
                        oldHardware.hardware_status = updatedHardware.Hardware_Status;
                    }
                }

                await _context.SaveChangesAsync();
                //return CreatedAtRoute("DefaultApi", new { id = oldHardware.CSPNAssetTag }, oldHardware);
                return Ok();
                
            }
            catch (Exception)
            {
                throw new InvalidOperationException();
            }
        }


        [HttpDelete]
        [ResponseType(typeof(Hardware))]
        public async Task<IHttpActionResult> DeleteHardware(int id)
        {
            Hardware hardware = await _context.Hardwares.FindAsync(id);
            if (hardware == null)
            {
                return NotFound();
            }

            _context.Hardwares.Remove(hardware);
            await _context.SaveChangesAsync();

            return Ok(hardware);
        }
    }

}
