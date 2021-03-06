﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.cspnetworks.net.Controllers
{
    public class DropDownsController : ApiController
    {
         private CSPFRAMEWORKEntities _context;

         public DropDownsController()
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

        // GET api/DropDowns/GetUserGroups
        [HttpGet]
        public Dictionary<String, String> GetUserGroups()
        {
            IQueryable<User_Groups> userGroups = _context.User_Groups;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            foreach (var userGroup in userGroups)
            {
                dictionary.Add(userGroup.user_group, userGroup.user_group);
            }
            return dictionary;
        }

        [HttpGet]
        public Dictionary<String, String> GetUserStatus()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Status_Types"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                   where values.enum_type_id == enumType.enum_type_id
                                                   select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }            
            return null;
        }

        [HttpGet]
        public Dictionary<String, String> GetCustomers()
        {
            IQueryable<Client> clients = _context.Clients;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            foreach (var item in clients)
            {
                dictionary.Add(item.company_name + " (" + item.client_code + ")", item.client_id.ToString());
            }
            return dictionary;
        }

        public Dictionary<String, String> GetFunctions()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Functions"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                   where values.enum_type_id == enumType.enum_type_id
                                                   select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;            
        }

        public Dictionary<String, String> GetVendorsList()
        {
            IQueryable<Vendor> vendors = _context.Vendors;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            foreach (var item in vendors)
            {
                dictionary.Add(item.name, item.vendor_id.ToString());
            }
            return dictionary;
        }


        public Dictionary<String, String> GetTeamList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "CSP_Teams"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String, String> GetHardwareMakeList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Hardware_Makes"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String, String> GetSoftwareMakeList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Software_Makes"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String, String> GetSoftwareModelList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Software_Models"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String, String> GetSoftware_LicenseList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Software_Licenses"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String, String> GetSoftware_MediaList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Software_Media"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }
        

        public Dictionary<String, String> GetHardwareItemList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Hardware_Items"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String, String> GetHardwareStatusList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "Hardware_Status"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String, String> GetSoftwareItemList()
        {
            IQueryable<Software> softwarelist = _context.Softwares;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            dictionary.Add("No Software", "0");
            foreach (var item in softwarelist)
            {
                //dictionary.Add(item.software_name, item.software_id.ToString());
                dictionary.Add(item.CSPNAssetTag.ToString(), item.CSPNAssetTag.ToString());
            }
            return dictionary;
        }


        public Dictionary<String, String> GetHardwareList()
        {
            IQueryable<Hardware> hardwarelist = _context.Hardwares;
            Dictionary<String, String> dictionary = new Dictionary<String, String>();

            foreach (var item in hardwarelist)
            {
                dictionary.Add(item.CSPNAssetTag.ToString(), item.CSPNAssetTag.ToString());
                
            }
            return dictionary;
        }

        public Dictionary<String, String> GetPurchaserList()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "PurchasedBy"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String, String> GetClientServices()
        {
            Enum_Types enumType = (from enums in _context.Enum_Types
                                   where enums.enum_type_name == "CSP_Services"
                                   select enums).FirstOrDefault();
            if (enumType != null)
            {
                IQueryable<Enum_Type_Values> enumTypeValues = (from values in _context.Enum_Type_Values
                                                               where values.enum_type_id == enumType.enum_type_id
                                                               select values);
                if (enumTypeValues != null)
                {
                    Dictionary<String, String> dictionary = new Dictionary<String, String>();
                    foreach (var item in enumTypeValues)
                    {
                        dictionary.Add(item.enum_type_value, item.enum_type_value_id.ToString());
                    }
                    return dictionary;
                }
            }
            return null;
        }

        public Dictionary<String,String> GetCSPUsers() {

             Client client = (from clientDB in _context.Clients
                             where clientDB.client_code == "CSP"
                             select clientDB).FirstOrDefault();
             if (client != null)
             {
                 Dictionary<String, String> dictionary = new Dictionary<String, String>();
                 IQueryable<User> user = (from values in _context.Users
                                          where values.client_id == client.client_id
                                         select values);
                 if (user != null) {
                     foreach (var userItem in user)
                     {
                         dictionary.Add(userItem.user_id.ToString(), userItem.firstname + " (" + userItem.email + ")");
                     }
                 }

                 return dictionary;

             }
             return null;
        }

        public Dictionary<String, String> GetSites(int id) {

            IQueryable<Client_Site> clientSites = (from site in _context.Client_Site
                                                     where site.client_id == id
                                                   select site);

            Dictionary<String,String> dictionary = new Dictionary< String,String>();

            if (clientSites != null)
            {
                foreach (var item in clientSites)
                {
                    dictionary.Add(item.client_site_id.ToString(), item.site_name);
                }    
            }
            
            return dictionary;
        }
    }
}
